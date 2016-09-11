#3. Loading Data

##Bank Marketing Data Set

For this workshop we will be using a bank marketing data set taken from the (UCI Machine Learning Repository) [https://archive.ics.uci.edu/ml/index.html]. This dataset contains about 4500 records of marketing campaign calls to the clients of a Portuguese bank. Each record contains a number of input variables likage __age__, __occupation__, and the __month__, and a simple __yes/no__ output variable indicating whether or not the client subscribed to the product on offer.

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
