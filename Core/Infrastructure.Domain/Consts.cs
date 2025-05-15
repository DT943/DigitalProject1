using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Domain
{
    public static class Consts
    {
        public enum Gender
        {
            Male,
            Female
        }
        public enum ServiceName {
            CMS,
            //Offer,
            Authentication,
            CWCore,
            Gallery,
            //Hotel,
            Notification,
            B2B
        }


        public static class Servics
        {
            public static readonly string GALLERY = "Gallery";
            public static readonly string HOTEL = "Hotel";
            public static readonly string EVENT = "Event";
            public static readonly string CMS = "CMS";
            public static readonly string OFFER = "Offer";
            public static readonly string CWCORE = "CWCore";
            public static readonly string NOTIFICATION = "Notification";
            public static readonly string AUTHENTICATION = "Authentication";
            public static readonly string HR = "HR";
            public static readonly string BranchesManagement = "BranchesManagement";
            public static readonly string B2B = "B2B";
            public static readonly string Loyalty = "Loyalty";
        }

        public static class RideRequestStatus
        {
            public static readonly string PENDING = "Pending";
            public static readonly string CANCELLED = "Cancelled";
            public static readonly string FINISHED = "Finished";
            public static readonly string INPROGRESS = "InProgress";
        }
    }
}
