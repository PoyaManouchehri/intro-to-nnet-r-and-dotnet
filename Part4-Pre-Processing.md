#4. Pre-Processing the Data

Before we can use the data for training a neural network, some pre-processing is required. This is not only to ensure the data is in a format that can be used by the algorithm, but also to optimize the speed and accuracy of our results. Typically two pre-processing steps are preformed for a dataset like ours, which is detailed below.

##Encoding Categorical Columns (optional reading)

A training algorithm works only with numerical data. Therefore we need to convert our categorical data, like occupation and maritial status, to a numerical format. We cannot, however, simply assign a number to each option as that would imply that some options are numerically greater than others. Instead, typically a categorical variable is split into multiple numerical variables, each represnting one of the options. For example:

```
Maritial Status: Married, Single, Divorced

            Input1   Input2   Input3
Married  =>   1        0        0
Single   =>   0        1        0
Divorced =>   0        0        1
```

For our purposes we don't need to worry about this, because the [nnet](https://cran.r-project.org/web/packages/nnet/index.html) already handles categorical data


##Normalizing/Standardizing Numerical Columns

Another useful optimization is standardizing numerical data so that different inputs fall into comparable ranges. While this is not strictly affect being able to arrive at an optimal solutions, in practice it can greatly improve how quickly we arrive at it. To accomplish this, scale and offset each column to have a mean of 0 and standard deviation of 1:

1. Open the `RWorkshop.R` script again.
2. In `loadBankMarketingData()`, after loading the CSV, let's identify columns that are integers (all our numerical data in this data set are integers)

  ```R
  isIntegerCol <- sapply(bankData, is.integer) 
  ```
  
  `sapply()` is one of several sepecial _apply_ functions in R. It's an efficient way executes any given function on a data frame or vector. In this case `isIntegerCol` will hold a vector of length 17, with a `TRUE` for each column that is of integer type.

3. Next we will apply the `scale()` function to these columns which centers and scales them to mean = 0, sd = 1. R allows us to use the boolean vector created above as a way to index into our data frame:

  ```R
  bankData[isIntegerCol] <- sapply(bankData[isIntegerCol], scale)
  ```
  
  The completed function should look like this:
  
  ```R
  loadBankMarketingData <- function()
  {
    bankData <- read.csv("C:/Path/ToYourCsv/BankMarketing.csv")
    isIntegerCol <- sapply(bankData, is.integer)
    bankData[isIntegerCol] <- lapply(bankData[isIntegerCol], scale)
    return(bankData)
  }
  ```
  
4. Execute the `loadBankMarketingData()`, assign it to a variable and inspect the result.
  
5. Optional Extra: execute the steps above in the console and view the outputs of the `sapply()`, `lapply()` and `scale()` along the way.
  
#End of Part 4

Our data set is now ready for [Part 5 - Training a neural network](Part5-Training-Neural-Net).
