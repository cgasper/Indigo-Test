using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace IndigoTest.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/region/")]
    public class CovidController : ControllerBase
    {
        private readonly string csvUrl = "https://raw.githubusercontent.com/sledilnik/data/master/csv/region-cases.csv";

        [HttpGet("cases")]
        public ActionResult<object> GetData(string region, [FromQuery] string startDate, [FromQuery] string endDate)
        {
            var csvUrl = "https://raw.githubusercontent.com/sledilnik/data/master/csv/region-cases.csv";

            var csvData = new List<string[]>();

            using (var csvParser = new TextFieldParser(new StringReader(new System.Net.WebClient().DownloadString(csvUrl))))
            {
                csvParser.TextFieldType = FieldType.Delimited;
                csvParser.SetDelimiters(",");
                while (!csvParser.EndOfData)
                {
                    csvData.Add(csvParser.ReadFields());
                }
            }

            var regionData = new Dictionary<string, Dictionary<string, string>>();

            foreach (var row in csvData.Skip(1)) // skip header row
            {
                var date = row[0];
                // Date filter startDate representing FROM, endDate representing TO
                if (!string.IsNullOrEmpty(startDate) && DateTime.Parse(date) < DateTime.Parse(startDate))
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(endDate) && DateTime.Parse(date) > DateTime.Parse(endDate))
                {
                    break;
                }
                /*The indexes of each column from the CSV file, 
                 * removing the comments will enable to output the remaining data if needed */
                if (region.ToLower() == "ce")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "CE" },
                        { "ActiveCases", row[1] },
                        //{ "ConfirmedToDate", row[2] },
                        { "DeceasedToDate", row[3] },
                        { "Vaccinated1stToDate", row[4] },
                        { "Vaccinated2ndToDate", row[5] }
                        //{ "Vaccinated3rdToDate", row[6] }
                    };
                    }
                }
                /*else if (region.ToLower() == "foreign")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                        {
                            { "Region", "Foreign" },
                            { "ActiveCases", row[7] },
                            { "ConfirmedToDate", row[8] },
                            { "DeceasedToDate", row[9] }
                        };
                    }
                }*/
                else if (region.ToLower() == "kk")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "KK" },
                        { "ActiveCases", row[10] },
                        //{ "ConfirmedToDate", row[11] },
                        { "DeceasedToDate", row[12] },
                        { "Vaccinated1stToDate", row[13] },
                        { "Vaccinated2ndToDate", row[14] },
                        //{ "Vaccinated3rdToDate", row[15] }
                    };
                    }
                }
                else if (region.ToLower() == "kp")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "KP" },
                        { "ActiveCases", row[16] },
                        //{ "ConfirmedToDate", row[17] },
                        { "DeceasedToDate", row[18] },
                        { "Vaccinated1stToDate", row[19] },
                        { "Vaccinated2ndToDate", row[20] },
                        //{ "Vaccinated3rdToDate", row[21] }
                    };
                    }
                }
                else if (region.ToLower() == "kr")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "KR" },
                        { "ActiveCases", row[22] },
                        //{ "ConfirmedToDate", row[23] },
                        { "DeceasedToDate", row[24] },
                        { "Vaccinated1stToDate", row[25] },
                        { "Vaccinated2ndToDate", row[26] },
                        //{ "Vaccinated3rdToDate", row[27] }
                    };
                    }
                }
                else if (region.ToLower() == "lj")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "LJ" },
                        { "ActiveCases", row[28] },
                        //{ "ConfirmedToDate", row[29] },
                        { "DeceasedToDate", row[30] },
                        { "Vaccinated1stToDate", row[31] },
                        { "Vaccinated2ndToDate", row[32] },
                        //{ "Vaccinated3rdToDate", row[33] }
                    };
                    }
                }
                else if (region.ToLower() == "mb")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "MB" },
                        { "ActiveCases", row[34] },
                        //{ "ConfirmedToDate", row[35] },
                        { "DeceasedToDate", row[36] },
                        { "Vaccinated1stToDate", row[37] },
                        { "Vaccinated2ndToDate", row[38] },
                        //{ "Vaccinated3rdToDate", row[39] }
                    };
                    }
                }
                else if (region.ToLower() == "ms")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "MS" },
                        { "ActiveCases", row[40] },
                        //{ "ConfirmedToDate", row[41] },
                        { "DeceasedToDate", row[42] },
                        { "Vaccinated1stToDate", row[43] },
                        { "Vaccinated2ndToDate", row[44] },
                        //{ "Vaccinated3rdToDate", row[45] }
                    };
                    }
                }
                else if (region.ToLower() == "ng")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "NG" },
                        { "ActiveCases", row[46] },
                        //{ "ConfirmedToDate", row[47] },
                        { "DeceasedToDate", row[48] },
                        { "Vaccinated1stToDate", row[49] },
                        { "Vaccinated2ndToDate", row[50] },
                        //{ "Vaccinated3rdToDate", row[51] }
                    };
                    }
                }
                else if (region.ToLower() == "nm")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "NM" },
                        { "ActiveCases", row[52] },
                        //{ "ConfirmedToDate", row[53] },
                        { "DeceasedToDate", row[54] },
                        { "Vaccinated1stToDate", row[55] },
                        { "Vaccinated2ndToDate", row[56] },
                        //{ "Vaccinated3rdToDate", row[57] }
                    };
                    }
                }
                else if (region.ToLower() == "po")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "PO" },
                        { "ActiveCases", row[58] },
                        //{ "ConfirmedToDate", row[59] },
                        { "DeceasedToDate", row[60] },
                        { "Vaccinated1stToDate", row[61] },
                        { "Vaccinated2ndToDate", row[62] },
                        //{ "Vaccinated3rdToDate", row[63] }
                    };
                    }
                }
                else if (region.ToLower() == "sg")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "SG" },
                        { "ActiveCases", row[64] },
                        //{ "ConfirmedToDate", row[65] },
                        { "DeceasedToDate", row[66] },
                        { "Vaccinated1stToDate", row[67] },
                        { "Vaccinated2ndToDate", row[68] },
                        //{ "Vaccinated3rdToDate", row[69] }
                    };
                    }
                }
                /*else if (region.ToLower() == "unknown")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                        {
                            { "Region", "UNKNOWN" },
                            { "ActiveCases", row[70] },
                            //{ "ConfirmedToDate", row[71] },
                            { "DeceasedToDate", row[72] },
                        };
                    }
                }*/
                else if (region.ToLower() == "za")
                {
                    if (!regionData.ContainsKey(date))
                    {
                        regionData[date] = new Dictionary<string, string>
                    {
                        { "Region", "ZA" },
                        { "ActiveCases", row[73] },
                        //{ "ConfirmedToDate", row[74] },
                        { "DeceasedToDate", row[75] },
                        { "Vaccinated1stToDate", row[76] },
                        { "Vaccinated2ndToDate", row[77] },
                        //{ "Vaccinated3rdToDate", row[78] }
                    };
                    }
                }
            }

            var result = new
            {
                Region = region.ToUpper(),
                StartDate = startDate,
                EndDate = endDate,
                RegionData = regionData
            };

            return Ok(result);

        }

        [HttpGet("lastweek")]
        public ActionResult<object> GetData()
        {
            var csvUrl = "https://raw.githubusercontent.com/sledilnik/data/master/csv/region-cases.csv";
            var csvData = new List<string[]>();

            using (var csvParser = new TextFieldParser(new StringReader(new System.Net.WebClient().DownloadString(csvUrl))))
            {
                csvParser.TextFieldType = FieldType.Delimited;
                csvParser.SetDelimiters(",");
                while (!csvParser.EndOfData)
                {
                    csvData.Add(csvParser.ReadFields());
                }
            }

            // Calculate the average number of new daily cases in the last 7 days per each region
            var regionsData = new List<RegionData>();
            foreach (var regionIndex in RegionIndexes)
            {
                var regionName = regionIndex.RegionName;
                var regionData = new List<int>();

                // Get the daily cases for the last 7 days for the region
                for (int i = csvData.Count - 1; i >= csvData.Count - 7; i--)
                {
                    var dailyCases = int.Parse(csvData[i][regionIndex.ConfirmedIndex]) - int.Parse(csvData[i - 1][regionIndex.ConfirmedIndex]);
                    regionData.Add(dailyCases);
                }

                // Calculate the average daily cases for the region
                var avgDailyCases = regionData.Average();

                // Add the region data to the list
                regionsData.Add(new RegionData { RegionName = regionName, AvgDailyCases = avgDailyCases });
            }

            // Sort the regions by the average daily cases in a descending order
            regionsData.Sort((r1, r2) => r2.AvgDailyCases.CompareTo(r1.AvgDailyCases));

            // Create the result object
            var result = new
            {
                lastweekData = regionsData
            };

            return Ok(result);
        }

        // The indexes of the ConfirmedToDate columns for each region in the CSV file
        private static readonly List<RegionIndex> RegionIndexes = new List<RegionIndex>
        {
            new RegionIndex { RegionName = "CE", ConfirmedIndex = 2 },
            new RegionIndex { RegionName = "Foreign", ConfirmedIndex = 8 },
            new RegionIndex { RegionName = "KK", ConfirmedIndex = 11 },
            new RegionIndex { RegionName = "KP", ConfirmedIndex = 17 },
            new RegionIndex { RegionName = "KR", ConfirmedIndex = 23 },
            new RegionIndex { RegionName = "LJ", ConfirmedIndex = 29 },
            new RegionIndex { RegionName = "MB", ConfirmedIndex = 35 },
            new RegionIndex { RegionName = "MS", ConfirmedIndex = 41 },
            new RegionIndex { RegionName = "NG", ConfirmedIndex = 47 },
            new RegionIndex { RegionName = "NM", ConfirmedIndex = 53 },
            new RegionIndex { RegionName = "PO", ConfirmedIndex = 59 },
            new RegionIndex { RegionName = "SG", ConfirmedIndex = 65 },
            new RegionIndex { RegionName = "Unknown", ConfirmedIndex = 70 },
            new RegionIndex { RegionName = "ZA", ConfirmedIndex = 74 }
        };

        // The index of a region in the RegionIndexes list
        private class RegionIndex
        {
            public string RegionName { get; set; }
            public int ConfirmedIndex { get; set; }
        }

        // The data for a region, including its name and average daily cases
        private class RegionData
        {
            public string RegionName { get; set; }
            public double AvgDailyCases { get; set; }
        }
    }
}

