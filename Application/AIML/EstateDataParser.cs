using Microsoft.ML;

namespace Application.AIML
{
    public static class EstateDataParser
    {
        private static MLContext mlContext = new MLContext();
        public static IDataView GetEstates()
        {
            string path = Path.GetFullPath("../Application/Data/data.csv");
            var dataView = mlContext.Data.LoadFromTextFile<EstateData>(path, hasHeader: true, separatorChar: ',');

            //// Filter out rows with missing values, excluding the Bedrooms column
            //var columnsToCheck = new string[] { nameof(EstateData.Price), nameof(EstateData.Street), nameof(EstateData.City), nameof(EstateData.ZipCode), nameof(EstateData.HouseSize) };
            //var filteredDataView = mlContext.Data.FilterRowsByMissingValues(dataView, columnsToCheck);


            return dataView;
        }
    }
}
