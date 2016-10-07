using System;

namespace SpecFlow.Extensions.Framework.Helpers
{
    public static class StateHelper
    {
        public static string Name(string stateAbbreviation)
        {
            switch (stateAbbreviation.ToUpper())
            {
                case "AL":
                    return "Alabama";

                case "AK":
                    return "Alaska";

                case "AS":
                    return "American Samoa";

                case "AZ":
                    return "Arizona";

                case "AR":
                    return "Arkansas";

                case "CA":
                    return "California";

                case "CO":
                    return "Colorado";

                case "CT":
                    return "Connecticut";

                case "DE":
                    return "Delaware";

                case "DC":
                    return "District of Columbia";

                case "FM":
                    return "Federated States of Micronesia";

                case "FL":
                    return "Florida";

                case "GA":
                    return "Georgia";

                case "GU":
                    return "Guam";

                case "HI":
                    return "Hawaii";

                case "ID":
                    return "Idaho";

                case "IL":
                    return "Illinois";

                case "IN":
                    return "Indiana";

                case "IA":
                    return "Iowa";

                case "KS":
                    return "Kansas";

                case "KY":
                    return "Kentucky";

                case "LA":
                    return "Louisiana";

                case "ME":
                    return "Maine";

                case "MH":
                    return "Marshall Islands";

                case "MD":
                    return "Maryland";

                case "MA":
                    return "Massachusetts";

                case "MI":
                    return "Michigan";

                case "MN":
                    return "Minnesota";

                case "MS":
                    return "Mississippi";

                case "MO":
                    return "Missouri";

                case "MT":
                    return "Montana";

                case "NE":
                    return "Nebraska";

                case "NV":
                    return "Nevada";

                case "NH":
                    return "New Hampshire";

                case "NJ":
                    return "New Jersey";

                case "NM":
                    return "New Mexico";

                case "NY":
                    return "New York";

                case "NC":
                    return "North Carolina";

                case "ND":
                    return "North Dakota";

                case "MP":
                    return "Northern Mariana Islands";

                case "OH":
                    return "Ohio";

                case "OK":
                    return "Oklahoma";

                case "OR":
                    return "Oregon";

                case "PW":
                    return "Palau";

                case "PA":
                    return "Pennsylvania";

                case "PR":
                    return "Puerto Rico";

                case "RI":
                    return "Rhode Island";

                case "SC":
                    return "South Carolina";

                case "SD":
                    return "South Dakota";

                case "TN":
                    return "Tennesse";

                case "TX":
                    return "Texas";

                case "UT":
                    return "Utah";

                case "VT":
                    return "Vermont";

                case "VI":
                    return "Virgin Islands";

                case "VA":
                    return "Virginia";

                case "WA":
                    return "Washington";

                case "WV":
                    return "West Virginia";

                case "WI":
                    return "Wisconsin";

                case "WY":
                    return "Wyoming";

                // already a name
                case "ALABAMA":
                case "ALASKA":
                case "AMERICAN SAMOA":
                case "ARIZONA":
                case "ARKANSAS":
                case "CALIFORNIA":
                case "COLORADO":
                case "CONNECTICUT":
                case "DELAWARE":
                case "DISTRICT OF COLUMBIA":
                case "FEDERATED STATES OF MICRONESIA":
                case "FLORIDA":
                case "GEORGIA":
                case "GUAM":
                case "HAWAII":
                case "IDAHO":
                case "ILLINOIS":
                case "INDIANA":
                case "IOWA":
                case "KANSAS":
                case "KENTUCKY":
                case "LOUISIANA":
                case "MAINE":
                case "MARSHALL ISLANDS":
                case "MARYLAND":
                case "MASSACHUSETTS":
                case "MICHIGAN":
                case "MINNESOTA":
                case "MISSISSIPPI":
                case "MISSOURI":
                case "MONTANA":
                case "NEBRASKA":
                case "NEVADA":
                case "NEW HAMPSHIRE":
                case "NEW JERSEY":
                case "NEW MEXICO":
                case "NEW YORK":
                case "NORTH CAROLINA":
                case "NORTH DAKOTA":
                case "NORTHERN MARIANA ISLANDS":
                case "OHIO":
                case "OKLAHOMA":
                case "OREGON":
                case "PALAU":
                case "PENNSYLVANIA":
                case "PUERTO RICO":
                case "RHODE ISLAND":
                case "SOUTH CAROLINA":
                case "SOUTH DAKOTA":
                case "TENNESSEE":
                case "TEXAS":
                case "UTAH":
                case "VERMONT":
                case "VIRGIN ISLANDS":
                case "VIRGINIA":
                case "WASHINGTON":
                case "WEST VIRGINIA":
                case "WISCONSIN":
                case "WYOMING":
                    return stateAbbreviation.ToUpper();

            }

            throw new NotSupportedException();
        }

        public static string Abbreviation(string name)
        {
            switch (name.ToUpper())
            {
                case "ALABAMA":
                    return "AL";

                case "ALASKA":
                    return "AK";

                case "AMERICAN SAMOA":
                    return "AS";

                case "ARIZONA":
                    return "AZ";

                case "ARKANSAS":
                    return "AR";

                case "CALIFORNIA":
                    return "CA";

                case "COLORADO":
                    return "CO";

                case "CONNECTICUT":
                    return "CT";

                case "DELAWARE":
                    return "DE";

                case "DISTRICT OF COLUMBIA":
                    return "DC";

                case "FEDERATED STATES OF MICRONESIA":
                    return "FM";

                case "FLORIDA":
                    return "FL";

                case "GEORGIA":
                    return "GA";

                case "GUAM":
                    return "GU";

                case "HAWAII":
                    return "HI";

                case "IDAHO":
                    return "ID";

                case "ILLINOIS":
                    return "IL";

                case "INDIANA":
                    return "IN";

                case "IOWA":
                    return "IA";

                case "KANSAS":
                    return "KS";

                case "KENTUCKY":
                    return "KY";

                case "LOUISIANA":
                    return "LA";

                case "MAINE":
                    return "ME";

                case "MARSHALL ISLANDS":
                    return "MH";

                case "MARYLAND":
                    return "MD";

                case "MASSACHUSETTS":
                    return "MA";

                case "MICHIGAN":
                    return "MI";

                case "MINNESOTA":
                    return "MN";

                case "MISSISSIPPI":
                    return "MS";

                case "MISSOURI":
                    return "MO";

                case "MONTANA":
                    return "MT";

                case "NEBRASKA":
                    return "NE";

                case "NEVADA":
                    return "NV";

                case "NEW HAMPSHIRE":
                    return "NH";

                case "NEW JERSEY":
                    return "NJ";

                case "NEW MEXICO":
                    return "NM";

                case "NEW YORK":
                    return "NY";

                case "NORTH CAROLINA":
                    return "NC";

                case "NORTH DAKOTA":
                    return "ND";

                case "NORTHERN MARIANA ISLANDS":
                    return "MP";

                case "OHIO":
                    return "OH";

                case "OKLAHOMA":
                    return "OK";

                case "OREGON":
                    return "OR";

                case "PALAU":
                    return "PW";

                case "PENNSYLVANIA":
                    return "PA";

                case "PUERTO RICO":
                    return "PR";

                case "RHODE ISLAND":
                    return "RI";

                case "SOUTH CAROLINA":
                    return "SC";

                case "SOUTH DAKOTA":
                    return "SD";

                case "TENNESSEE":
                    return "TN";

                case "TEXAS":
                    return "TX";

                case "UTAH":
                    return "UT";

                case "VERMONT":
                    return "VT";

                case "VIRGIN ISLANDS":
                    return "VI";

                case "VIRGINIA":
                    return "VA";

                case "WASHINGTON":
                    return "WA";

                case "WEST VIRGINIA":
                    return "WV";

                case "WISCONSIN":
                    return "WI";

                case "WYOMING":
                    return "WY";

                // already an abbreviation
                case "AL":
                case "AK":
                case "AS":
                case "AZ":
                case "AR":
                case "CA":
                case "CO":
                case "CT":
                case "DE":
                case "DC":
                case "FM":
                case "FL":
                case "GA":
                case "GU":
                case "HI":
                case "ID":
                case "IL":
                case "IN":
                case "IA":
                case "KS":
                case "KY":
                case "LA":
                case "ME":
                case "MH":
                case "MD":
                case "MA":
                case "MI":
                case "MN":
                case "MS":
                case "MO":
                case "MT":
                case "NE":
                case "NV":
                case "NH":
                case "NJ":
                case "NM":
                case "NY":
                case "NC":
                case "ND":
                case "MP":
                case "OH":
                case "OK":
                case "OR":
                case "PW":
                case "PA":
                case "PR":
                case "RI":
                case "SC":
                case "SD":
                case "TN":
                case "TX":
                case "UT":
                case "VT":
                case "VI":
                case "VA":
                case "WA":
                case "WV":
                case "WI":
                case "WY":
                    return name.ToUpper();
            }
            throw new NotSupportedException();
        }

        public static string Name(State state)
        {
            switch (state)
            {
                case State.AL:
                    return "Alabama";

                case State.AK:
                    return "Alaska";

                case State.AS:
                    return "American Samoa";

                case State.AZ:
                    return "Arizona";

                case State.AR:
                    return "Arkansas";

                case State.CA:
                    return "California";

                case State.CO:
                    return "Colorado";

                case State.CT:
                    return "Connecticut";

                case State.DE:
                    return "Delaware";

                case State.DC:
                    return "District of Columbia";

                case State.FM:
                    return "Federated States of Micronesia";

                case State.FL:
                    return "Florida";

                case State.GA:
                    return "Georgia";

                case State.GU:
                    return "Guam";

                case State.HI:
                    return "Hawaii";

                case State.ID:
                    return "Idaho";

                case State.IL:
                    return "Illinois";

                case State.IN:
                    return "Indiana";

                case State.IA:
                    return "Iowa";

                case State.KS:
                    return "Kansas";

                case State.KY:
                    return "Kentucky";

                case State.LA:
                    return "Louisiana";

                case State.ME:
                    return "Maine";

                case State.MH:
                    return "Marshall Islands";

                case State.MD:
                    return "Maryland";

                case State.MA:
                    return "Massachusetts";

                case State.MI:
                    return "Michigan";

                case State.MN:
                    return "Minnesota";

                case State.MS:
                    return "Mississippi";

                case State.MO:
                    return "Missouri";

                case State.MT:
                    return "Montana";

                case State.NE:
                    return "Nebraska";

                case State.NV:
                    return "Nevada";

                case State.NH:
                    return "New Hampshire";

                case State.NJ:
                    return "New Jersey";

                case State.NM:
                    return "New Mexico";

                case State.NY:
                    return "New York";

                case State.NC:
                    return "North Carolina";

                case State.ND:
                    return "North Dakota";

                case State.MP:
                    return "Northern Mariana Islands";

                case State.OH:
                    return "Ohio";

                case State.OK:
                    return "Oklahoma";

                case State.OR:
                    return "Oregon";

                case State.PW:
                    return "Palau";

                case State.PA:
                    return "Pennsylvania";

                case State.PR:
                    return "Puerto Rico";

                case State.RI:
                    return "Rhode Island";

                case State.SC:
                    return "South Carolina";

                case State.SD:
                    return "South Dakota";

                case State.TN:
                    return "Tennesse";

                case State.TX:
                    return "Texas";

                case State.UT:
                    return "Utah";

                case State.VT:
                    return "Vermont";

                case State.VI:
                    return "Virgin Islands";

                case State.VA:
                    return "Virginia";

                case State.WA:
                    return "Washington";

                case State.WV:
                    return "West Virginia";

                case State.WI:
                    return "Wisconsin";

                case State.WY:
                    return "Wyoming";
            }
            throw new NotSupportedException();
        }

        public static State ByName(string name)
        {
            switch (name.ToUpper())
            {
                case "ALABAMA":
                    return State.AL;

                case "ALASKA":
                    return State.AK;

                case "AMERICAN SAMOA":
                    return State.AS;

                case "ARIZONA":
                    return State.AZ;

                case "ARKANSAS":
                    return State.AR;

                case "CALIFORNIA":
                    return State.CA;

                case "COLORADO":
                    return State.CO;

                case "CONNECTICUT":
                    return State.CT;

                case "DELAWARE":
                    return State.DE;

                case "DISTRICT OF COLUMBIA":
                    return State.DC;

                case "FEDERATED STATES OF MICRONESIA":
                    return State.FM;

                case "FLORIDA":
                    return State.FL;

                case "GEORGIA":
                    return State.GA;

                case "GUAM":
                    return State.GU;

                case "HAWAII":
                    return State.HI;

                case "IDAHO":
                    return State.ID;

                case "ILLINOIS":
                    return State.IL;

                case "INDIANA":
                    return State.IN;

                case "IOWA":
                    return State.IA;

                case "KANSAS":
                    return State.KS;

                case "KENTUCKY":
                    return State.KY;

                case "LOUISIANA":
                    return State.LA;

                case "MAINE":
                    return State.ME;

                case "MARSHALL ISLANDS":
                    return State.MH;

                case "MARYLAND":
                    return State.MD;

                case "MASSACHUSETTS":
                    return State.MA;

                case "MICHIGAN":
                    return State.MI;

                case "MINNESOTA":
                    return State.MN;

                case "MISSISSIPPI":
                    return State.MS;

                case "MISSOURI":
                    return State.MO;

                case "MONTANA":
                    return State.MT;

                case "NEBRASKA":
                    return State.NE;

                case "NEVADA":
                    return State.NV;

                case "NEW HAMPSHIRE":
                    return State.NH;

                case "NEW JERSEY":
                    return State.NJ;

                case "NEW MEXICO":
                    return State.NM;

                case "NEW YORK":
                    return State.NY;

                case "NORTH CAROLINA":
                    return State.NC;

                case "NORTH DAKOTA":
                    return State.ND;

                case "NORTHERN MARIANA ISLANDS":
                    return State.MP;

                case "OHIO":
                    return State.OH;

                case "OKLAHOMA":
                    return State.OK;

                case "OREGON":
                    return State.OR;

                case "PALAU":
                    return State.PW;

                case "PENNSYLVANIA":
                    return State.PA;

                case "PUERTO RICO":
                    return State.PR;

                case "RHODE ISLAND":
                    return State.RI;

                case "SOUTH CAROLINA":
                    return State.SC;

                case "SOUTH DAKOTA":
                    return State.SD;

                case "TENNESSEE":
                    return State.TN;

                case "TEXAS":
                    return State.TX;

                case "UTAH":
                    return State.UT;

                case "VERMONT":
                    return State.VT;

                case "VIRGIN ISLANDS":
                    return State.VI;

                case "VIRGINIA":
                    return State.VA;

                case "WASHINGTON":
                    return State.WA;

                case "WEST VIRGINIA":
                    return State.WV;

                case "WISCONSIN":
                    return State.WI;

                case "WYOMING":
                    return State.WY;
            }
            throw new NotSupportedException();
        }

        public static State ByAbbreviation(string stateAbbreviation)
        {
            switch (stateAbbreviation.ToUpper())
            {
                case "AL":
                    return State.AL;

                case "AK":
                    return State.AK;

                case "AS":
                    return State.AS;

                case "AZ":
                    return State.AZ;

                case "AR":
                    return State.AR;

                case "CA":
                    return State.CA;

                case "CO":
                    return State.CO;

                case "CT":
                    return State.CT;

                case "DE":
                    return State.DE;

                case "DC":
                    return State.DC;

                case "FM":
                    return State.FM;

                case "FL":
                    return State.FL;

                case "GA":
                    return State.GA;

                case "GU":
                    return State.GU;

                case "HI":
                    return State.HI;

                case "ID":
                    return State.ID;

                case "IL":
                    return State.IL;

                case "IN":
                    return State.IN;

                case "IA":
                    return State.IA;

                case "KS":
                    return State.KS;

                case "KY":
                    return State.KY;

                case "LA":
                    return State.LA;

                case "ME":
                    return State.ME;

                case "MH":
                    return State.MH;

                case "MD":
                    return State.MD;

                case "MA":
                    return State.MA;

                case "MI":
                    return State.MI;

                case "MN":
                    return State.MN;

                case "MS":
                    return State.MS;

                case "MO":
                    return State.MO;

                case "MT":
                    return State.MT;

                case "NE":
                    return State.NE;

                case "NV":
                    return State.NV;

                case "NEW NH":
                    return State.NH;

                case "NJ":
                    return State.NJ;

                case "NM":
                    return State.NM;

                case "NY":
                    return State.NY;

                case "NC":
                    return State.NC;

                case "ND":
                    return State.ND;

                case "MP":
                    return State.MP;

                case "OH":
                    return State.OH;

                case "OK":
                    return State.OK;

                case "OR":
                    return State.OR;

                case "PW":
                    return State.PW;

                case "PA":
                    return State.PA;

                case "PR":
                    return State.PR;

                case "RI":
                    return State.RI;

                case "SC":
                    return State.SC;

                case "SD":
                    return State.SD;

                case "TN":
                    return State.TN;

                case "TX":
                    return State.TX;

                case "UT":
                    return State.UT;

                case "VT":
                    return State.VT;

                case "VI":
                    return State.VI;

                case "VA":
                    return State.VA;

                case "WA":
                    return State.WA;

                case "WV":
                    return State.WV;

                case "WI":
                    return State.WI;

                case "WY":
                    return State.WY;
            }
            throw new NotSupportedException();
        }

        public enum State
        {
            AL,
            AK,
            AS,
            AZ,
            AR,
            CA,
            CO,
            CT,
            DE,
            DC,
            FM,
            FL,
            GA,
            GU,
            HI,
            ID,
            IL,
            IN,
            IA,
            KS,
            KY,
            LA,
            ME,
            MH,
            MD,
            MA,
            MI,
            MN,
            MS,
            MO,
            MT,
            NE,
            NV,
            NH,
            NJ,
            NM,
            NY,
            NC,
            ND,
            MP,
            OH,
            OK,
            OR,
            PW,
            PA,
            PR,
            RI,
            SC,
            SD,
            TN,
            TX,
            UT,
            VT,
            VI,
            VA,
            WA,
            WV,
            WI,
            WY
        }
    }
}