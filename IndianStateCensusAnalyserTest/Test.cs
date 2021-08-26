using IndianStateCensusAnalyserProject.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using IndianStateCensusAnalyserProject;
using static IndianStateCensusAnalyserProject.CensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string indianStateCodeFilePath = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaStateCode.csv";
        string wrongIndianStateCodeFilePath = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaCode.csv";
        string wrongIndianStateCodeFiletype = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\IndiaStateCode.txt";
        string wrongIndianStateCodeFileDelimeter = @"D:\IndianStateCensusAnalyser\IndianStateCensusAnalyserProject\Utilities\\DelimiterIndiaStateCode.csv";
        string wrongIndianStateCodeHeaders = "SrNo,State Name,TIN,StateCode,Popularity";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC 2.1
        /// 
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);

        }
        /// <summary>
        /// TC-2.2
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        /// <summary>
        /// TC-2.3
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFiletype, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        /// <summary>
        /// TC-2.4
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        /// <summary>
        /// TC-2.5
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileNotProperHeader_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}