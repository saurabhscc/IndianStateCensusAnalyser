using IndianStateCensusAnalyserProject.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyserProject
{
    public class CensusAnalyser
    {
        //enum for creating instance for multiple countries
        /// <summary>
        ///taken only one Country for Simplicity.
        /// </summary>
        public enum Country
        {
            INDIA
        }
        // Dictionary to store the data from the CSV files
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Loads the census data.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data heade       
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
