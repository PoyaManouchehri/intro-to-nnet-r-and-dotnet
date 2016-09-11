#3. Loading Data

##Bank Marketing Data Set

For this workshop we will be using a bank marketing data set taken from the [UCI Machine Learning Repository] (https://archive.ics.uci.edu/ml/index.html). This dataset contains about 4500 records of marketing campaign calls to the clients of a Portuguese bank. Each record contains a number of input variables likage __age__, __occupation__, and the __month__, and a simple __yes/no__ output variable indicating whether or not the client subscribed to the product on offer. For a more detailed explanation of the data set and its parameters, click [here](https://archive.ics.uci.edu/ml/datasets/Bank+Marketing).

##Loading the CSV

1. Download and copy [BankMarketing.csv](Data/BankMarketing.csv) to a location of your choice
2. In __RStudio__ create a new R script with __File > New File > R Script__. Save and call it `RWokshop.R` or whatever else you fancy.
3. Let's create a new function called `loadBankMarketingData()`:

  ```
  loadBankMarketingData <- function()
  {
  }
  ```
  
4. R makes it very simple to load a CSV (and other common data files). On the first line of your function call `read.csv()`:

  ```
  bankData = read.csv("C:/Path/ToYourCsv/BankMarketing.csv")
  ```
  
  Note that no semicolons are used in R. 
  
5. We can now return the result:

  ```
  return(bankData)
  ```
  
##Viewing the Data

Now that we have written and saved the script, we can call it from an R session or in our case, the RStudio console.

1. Try callig the function from the console:

  ```
  loadBankMarketingData()
  ```
  
  What happens?
  
2. In order to access the function we first need to make it available to the current session. In the console enter:

  ```
  source("C:/Path/ToYourScript/BWorkshop.R")
  ```
  
3. __RStudio__ gives you a nice shortcut for doing this. Simply check the __Source on Save__ option at the top of the script. Now saving the file will automatically execute the `source()` function in the console.

![01-source-on-save](Part3-Content/01-source-on-save.png)

4. Now call the function again

  ```
  loadBankMarketingData()
  ```
  
  The output of our function is a _data frame_, an important data structure in R which holds a table of data which can have different column types. By default R will call the `print()` on the output of our function and to try to write out something useful. In this case you will see some of the CSV data followed by something like this:
  
  ```
  [ reached getOption("max.print") -- omitted 3933 rows ]
  ```
  
5. Again in the console call the function, but this time assign the result to a global variable

  ```
  data <- loadBankMarketingData()
  ```
  
  You will notice the variable appearing in the __Global Environment__ window. This means the variable is now available to be viewed and used in subsequent work that you do in the console window.
  
  ![02-global-variable](Part3-Content/02-global-variable.png)
  
6. Double click the variable to view its content or alternatively call `View(data)` from the console:

![03-data-frame-view](Part3-Content/03-data-frame-view.png)


##End of Part 3

We now have our data set loaded and stored in a data frame. Let's move on to [Part 4 - Pre-processing the data](Part4-Pre-Processing.md)
