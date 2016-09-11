run <- function()
{
  bankData = preProcessData(read.csv("C:/Dev/Readify/Presentations/NNWorkshop/bank.csv"))
  set.seed(1)
  sampleIndices = sample(nrow(bankData), 600)
  testSet = bankData[sampleIndices,]
  trainingSet = bankData[-sampleIndices,]

  nn <- train(trainingSet)
#  plot(nn, nid=T, max.sp=T)
  
  testResult <- predict(nn, testSet[,-17], type="class")
  total <- nrow(testSet)
  yesTotal <- length(which(testSet[, 17] == "yes"))
  noTotal <- length(which(testSet[, 17] == "no"))
  print (paste(total, yesTotal, noTotal))
  matches <- testResult[which(testResult == testSet[, 17])]
  print (length(matches)*100.0/total)
  print (length(which(matches == c("yes")))*100.0/yesTotal)
  print (length(which(matches == c("no")))*100.0/noTotal)
  
  return(nn)
}

train <- function(trainingSet)
{
  nn <- nnet(y~., trainingSet, MaxNWts=5000, size=25, maxit=10000)
  return(nn)
}