#5. Training a neural network

##Creating a Test Set

When training a model of any kind (neural networks included) it's often a good idea to use a portion of our data for testing. This means we break up the data set into a training set, and a test set. The test set allows us to see how well our model is doing against data it has never observed before, and gives us a way to compare and contrast different models.

1. Create a new function in `RWorkshop.R` called `runTraining()`

2. First let's load our data using the function we previously wrote:

  ```R
  bankData <- loadBankMarketingData()
  ```
 
3. Next, let's fix the R's random number generator seed. The purpose of this is so that across multiple runs our random selection of test cases (as well as any other initialization code in the neural network) is consistent, making them comparable.

  ```R
  set.seed(1)
  ```
  
4. Taking a random selection of rows from a data frame is very simple:

  ```R
  testIndices <- sample(nrow(bankData), 600)
  testSet <- bankData[testIndices,]
  trainingSet <- bankData[-testIndices,]
  ```
  
  
##Training the Neural Network

We previously installed and attached the `nnet` package which we will use to train our neural network.

1. In the same function, after splitting the data into test and training sets, call `nnet()`

  ```R
  bankModel <- nnet(y~., trainingSet, size=15, MaxNWts=5000, maxit=10000)
  ```
  
  The `nnet()` function accepts many parameters. The parameters stated above are:
  * __Formula (y~.):__ In R a forumla expression is a first class citizen. Here we are saying `y` is a function all other variables (denoted with a period) in our data frame. Note that y is the nam eof our output column.
  
  * __trainingSet:__ Our training data.
  
  * __Size:__ This is the number of neurons in the hidden layer
  
  * __MaxNWts:__ This is a limit on how many connections can exist in our model. If we have too many neurons in the model an error will be returned.
  
  * __maxit:__ The number of times the algorithm will iterate over our data. It is possible for the algorithm to determine it has reached convergance in which case it will stop earlier than this.