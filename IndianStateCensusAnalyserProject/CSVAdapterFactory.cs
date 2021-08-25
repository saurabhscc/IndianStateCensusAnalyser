
using IndianStateCensusAnalyserProject.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyserProject
{
    /// <summary>
    /// Factory Method Which return object IndianStateAdaptor Class
    /// </summary>
    public class CSVAdapterFactory
    {
        /// <summary>
        /// Loads the CSV data.and checking country matches or not
        /// </summary>
        /// <param name="country"></param>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
