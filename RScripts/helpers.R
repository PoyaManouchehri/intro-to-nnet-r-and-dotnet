preProcessData <- function(data)
{
#  encodedData <- model.matrix(~.-1, data=data)

#  maxs <- apply(encodedData, 2, max) 
#  mins <- apply(encodedData, 2, min)
  
#  normalizedData <- as.data.frame(scale(encodedData, center = mins, scale = maxs - mins))

  numIndices <- sapply(data, is.integer)
  normalizedData <- data;
  normalizedData[numIndices] <- lapply(normalizedData[numIndices], scale)

  return(normalizedData)
}
