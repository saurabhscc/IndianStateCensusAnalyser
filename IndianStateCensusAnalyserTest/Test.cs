using IndianStateCensusAnalyserProject.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using IndianStateCensusAnalyserProject;
using static IndianStateCensusAnalyserProject.CensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string indianStateCensusFilePath = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaStateCensusData.csv";
        string wrongIndianStateCensusFilePath = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaData.csv";
        string wrongIndianStateCensusFiletype = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaStateCensusData.txt";
        string wrongIndianStateCensusFileDelimiter = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\DelimiterIndiaStateCensusData.csv";
        string wrongIndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm,Rank";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC 1.1
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);

        }
        /// <summary>
        /// TC-1.2
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        /// <summary>
        /// TC-1.3
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFiletype, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        /// <summary>
        /// TC-1.4
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileDelimiter, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        /// <summary>
        /// TC-1.5
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileNotProperHeader_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileDelimiter, wrongIndianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}