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
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string indianStateCensusFilePath = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaStateCensusData.csv";
        string indianStateCodeFilePath = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaStateCode.csv";
        string wrongIndianStateCensusFilePath = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaData.csv";
        string wrongIndianStateCodeFilePath = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaCode.csv";
        string wrongIndianStateCensusFiletype = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaStateCensusData.txt";
        string wrongIndianStateCodeFiletype = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaStateCode.txt";
        string wrongIndianStateCensusFileDelimiter = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\DelimiterIndiaStateCensusData.csv";
        string wrongIndianStateCodeFileDelimeter = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\\DelimiterIndiaStateCode.csv";
        string wrongIndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm,Rank";
        string wrongIndianStateCodeHeaders = "SrNo,State Name,TIN,StateCode,Popularity";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC 1.1
        /// 
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);

        }
        /// <summary>
        /// TC-1.2
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        /// <summary>
        /// TC-1.3
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFiletype, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFiletype, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        /// <summary>
        /// TC-1.4
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileDelimiter, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        /// <summary>
        /// TC-1.5
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileNotProperHeader_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileDelimiter, wrongIndianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}