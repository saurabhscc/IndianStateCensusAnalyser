using IndianStateCensusAnalyserProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public abstract class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            // String to store the data from the csv file.
            string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            // Checks for the extension of the file path. If extension doesn't matches throws 
            // the custom exception for the invalid file type.
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            // Reading all the file data at the present file path.
            censusData = File.ReadAllLines(csvFilePath);

            // matches the file header present at the 0th position 
            // Of  the string array with data headers given.
            // If header is incorrect throws the custom exception 
            // for incorrect header in the data file.
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
