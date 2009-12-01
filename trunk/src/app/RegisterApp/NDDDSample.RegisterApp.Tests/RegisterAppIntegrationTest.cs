﻿namespace NDDDSample.RegisterApp.Tests
{
    #region Usings

    using System;
    using System.ServiceModel;

    using HandlingReportService;    

    using NUnit.Framework;
    
    using ViewModels;

    #endregion

    /// <summary>
    /// The register app validation test.
    /// </summary>
    [TestFixture]
    public class RegisterAppIntegrationTest
    {
        #region Fields

        private IHandlingReportService handlingReportServiceClient;

        private HandlingReportViewModel handlingReportViewModel;

        #endregion

        #region Public Methods

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            var basicHttpBinding = new BasicHttpBinding();
            basicHttpBinding.SendTimeout = TimeSpan.FromMinutes(5);
            var endpointAddress = new EndpointAddress("http://localhost:8088/HandlingReportServiceFacade/");            
            this.handlingReportServiceClient = new HandlingReportServiceClient(basicHttpBinding, endpointAddress);
            this.handlingReportViewModel = new HandlingReportViewModel(this.handlingReportServiceClient);
        }
        
        [Test]
        [ExpectedException(typeof(FaultException<HandlingReportException>))]
        public void TestHandlingReportViewModelValidation()
        {
            HandlingReport handlingReport = new HandlingReport();
            handlingReport.TrackingIds = new[] { "5" };
            handlingReport.Type = HandlingType.Load.ToString();
            handlingReport.UnLocode = "NYC";
            handlingReport.VoyageNumber = "123qwe";
            handlingReport.CompletionTime = DateTime.Now;
            this.handlingReportServiceClient.SubmitReport(handlingReport);
        }

        #endregion
    }
}