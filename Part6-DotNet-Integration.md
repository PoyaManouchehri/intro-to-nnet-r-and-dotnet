#6. Integrating the Model in an MVC Web Application

##Persisting the Model in R

Clearly we don't want train our neural network from scratch every time we need to make a prediction. R provides several functions including `saveRDS()` and `readRDS()` for persisting objects.

1. In the `loadBankMarketingData()` _remove_ the following line:
  ```R
  bankData[numberCols] <- sapply(bankData[numberCols], scale)
  ```

2. Let's instead calculate the mean and standard deviation explicitly:
  ```R
  means <- lapply(bankData[numberCols], mean)
  sds <- lapply(bankData[numberCols], sd)
  ```
  
3. Next we'll scale our data. This should give the same results as we had before with the `scale()` function:
  ```R
  bankData[numberCols] <- (bankData[numberCols] - means)/sds
  ```
  
4. Finally we can persist the means and standard deviations, so that we can apply them later when a prediction needs to be made:
  ```R
  saveRDS(means, file='C:/RWorkshop/Means.bin')
  saveRDS(sds, file='C:/RWorkshop/SDs.bin')
  ```

5. Persist the trained model by adding the following line just before returning in `trainBankModel()`
  ```R
  saveRDS(bankModel, file='C:/RWorkshop/BankModel.bin')
  ```

6. Rerun the training from the console and ensure all three files have been saved to disk.


##Making a Prediction

We'll now write a function which given one set of inputs, will use our persisted model to make a prediction.

1. Add a new function to `RWorkshop.R` called `makePrediction()`:
  ```R
  makePrediction <- function(input)
  {
  }
  ```
 
2. First, load our persisted model:
  
  ```R
  bankModel <- readRDS(file='C:/RWorkshop/BankModel.bin')
  means <- readRDS(file='C:/RWorkshop/Means.bin')
  sds <- readRDS(file='C:/RWorkshop/SDs.bin')
  ```
  
3. Let's apply the scaling to the input so that it matches what we trained the model with:
  ```R
  numberCols <- sapply(input, function(x) {return(is.numeric(x) | is.integer(x))})
  input[numberCols] = (input[numberCols] - means) / sds
  ```

4. Finally make a prediction and return the result, which is a single "yes" or "no" string:
  ```R
  result <- predict(bankModel, input, type="class")
  return(result[1])
  ```
  
  Note that the first element in the prediction result is a column description, hence we return the second element.
  

##Calling The Function from .NET

For your convenience a scaffold project has been created which allows you to enter all the input fields for the bank model and submit them for prediction. We just need to implement the interop with R.

0. Add R to your system path variables. For a 64-bit installation this will look something like this:

  ```
  C:\Program Files\R\R-3.3.1\bin\x64
  ```

1. Clone this repository or download the [BankMarketingWebsite](BankMarketingWebsite) solution.

2. Open `BankMarketingWebsite.sln` (be sure to restart it if you already had it open before you changed the PATH variable).

3. Using the __Nuget Package Manager__ UI or console add the latest version of the [`R.NET.Community`](https://www.nuget.org/packages/R.NET.Community/) package.

4. Open `Models\BankModel.cs`. We will be implementing the `WillSubscribe()` method which takes the input parameters for a client, and outputs a "yes" or "no" string.

5. First let's instantiate the R engine:
  
  ```CSharp
  var engine = REngine.GetInstance();
  ```
  
  This gives us access to the R interop (see notes at the bottom regarding multi-threading).
  
6. Attach the required `nnet` library. Keep in mind that we would typically do this in our script itself but for the sake of the example, we'll do it here:

  ```CSharp
  engine.Evaluate("library(nnet)");
  ```

7. Include our script source file:

  ```CSharp
  engine.Evaluate("source('C:/RWorkshop/RWorkshop.R')");
  ```
  
8. We'll now create an expression of our prediction function. Note that this will not actually call the function, but rather gives us a way to call it later with some additional arguments:

  ```CSharp
  var predictFunc = engine.Evaluate("makePrediction").AsFunction();
  ```
  
9. Create a data frame from our input data:
  ```CSharp
  var data = engine.CreateDataFrame(GetInputColumns(input), GetColumnNames());
  ```
  
  `CreateDataFrame()` accepts a list enumerables, each one including all the data for one column. In our case there will be a single row for each column. The column names are optional for this method, however our neural network model expects these names.
  
10. Call the prediction function and return the result:
  ```CSharp
  return predictFunc.Invoke(data).AsCharacter()[0];
  ```

11. Now run the application. You should be able put in some data in the input fields, click the __Will They Sign Up?__ button, and see the prediction result on the screen.


> __A word of warning__: R itself is a single-threaded environment and R.Net it not designed for concurrency. There is a single, static instance of `REngine` which is initialized on the thread where `GetInstance()` is first called. As such, it should _not_ be used directly in a multithreaded application like a website.
Interop with R could be useful in kicking of background R tasks but is definitely not suitable for a high volume of requests in the production environment. Either way some form of synchronization for access the `REngine` instance is required.
>

