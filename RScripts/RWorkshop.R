loadBankMarketingData <- function()
{
  bankData <- read.csv("C:/RWorkshop/BankMarketing.csv")
  numberCols <- sapply(bankData, function(x) {return(is.numeric(x) | is.integer(x))})
  means <- lapply(bankData[numberCols], mean)
  sds <- lapply(bankData[numberCols], sd)
  bankData[numberCols] <- (bankData[numberCols] - means)/sds
  saveRDS(means, file='C:/RWorkshop/Means.bin')
  saveRDS(sds, file='C:/RWorkshop/SDs.bin')
  return(bankData)
}

trainBankModel <- function()
{
  bankData <- loadBankMarketingData()
  set.seed(1)
  testIndices <- sample(nrow(bankData), 900)
  testSet <- bankData[testIndices,]
  trainingSet <- bankData[-testIndices,]
  
  bankModel <- nnet(Y~., trainingSet, size=10, MaxNWts=5000, maxit=2000)
  testBankModel(bankModel, testSet)
  saveRDS(bankModel, file='C:/RWorkshop/BankModel.bin')
  return(bankModel)
}

testBankModel <- function(bankModel, testSet)
{
  outputCol <- length(testSet)
  testPredictions <- predict(bankModel, testSet[,-outputCol], type="class")

  total <- nrow(testSet)
  yesTotal <- length(which(testSet[, outputCol] == "yes"))
  noTotal <- total - yesTotal

  matches <- testPredictions[which(testPredictions == testSet[, outputCol])]

  correctTotal <- length(matches)
  correctYes <- length(which(matches == c("yes")))
  correctNo <- correctTotal - correctYes

  print(paste("Correct - Total:", correctTotal*100/total))
  print(paste("Correct - Yes:", correctYes*100/yesTotal))
  print(paste("Correct - No:", correctNo*100/noTotal))
}

makePrediction <- function(input)
{
  bankModel <- readRDS(file='C:/RWorkshop/BankModel.bin')
  means <- readRDS(file='C:/RWorkshop/Means.bin')
  sds <- readRDS(file='C:/RWorkshop/SDs.bin')

  numberCols <- sapply(input, function(x) {return(is.numeric(x) | is.integer(x))})
  input[numberCols] = (input[numberCols] - means) / sds

  result <- predict(bankModel, input, type="class")
  return(result[1])
}

