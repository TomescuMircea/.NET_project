using Microsoft.ML;
using Microsoft.ML.Data;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AIML
{
    public class EstatePricePredictionModel
    {
        private readonly MLContext mlContext;
        private ITransformer model;
        private IDataView testData;

        public EstatePricePredictionModel() => mlContext = new MLContext();

        public RegressionMetrics Train(IDataView dataView)
        {
            // Split the data into training and testing sets
            var splitData = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var trainingData = splitData.TrainSet;
            testData = splitData.TestSet;

            // Define the data processing and training pipeline
            //var pipeline = mlContext.Transforms.Concatenate("Features", 
            //    nameof(EstateData.Price),nameof(EstateData.Bedrooms),nameof(EstateData.Bathrooms),nameof(EstateData.LandSize),nameof(EstateData.Street),nameof(EstateData.City),nameof(EstateData.ZipCode),nameof(EstateData.HouseSize))
            //    .Append(mlContext.Transforms.Conversion.MapValueToKey("price", nameof(EstateData.Price)))
            //    .Append(mlContext.Transforms.Conversion.MapValueToKey("bed", nameof(EstateData.Bedrooms)))
            //    .Append(mlContext.Transforms.Conversion.MapValueToKey("bath", nameof(EstateData.Bathrooms)))
            //    .Append(mlContext.Transforms.Conversion.MapValueToKey("acre_lot", nameof(EstateData.LandSize)))
            //    .Append(mlContext.Transforms.Conversion.MapValueToKey("street", nameof(EstateData.Street)))
            //    .Append(mlContext.Transforms.Conversion.MapValueToKey("city", nameof(EstateData.City)))
            //    .Append(mlContext.Transforms.Conversion.MapValueToKey("zip_code", nameof(EstateData.ZipCode)))
            //    .Append(mlContext.Transforms.Conversion.MapValueToKey("house_size", nameof(EstateData.HouseSize)))
            //    .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(EstateData.Price), maximumNumberOfIterations: 100));
            
            var pipeline = mlContext.Transforms.Text.FeaturizeText("StreetFeaturized", nameof(EstateData.Street))
                    .Append(mlContext.Transforms.Text.FeaturizeText("CityFeaturized", nameof(EstateData.City)))
                    .Append(mlContext.Transforms.Text.FeaturizeText("ZipCodeFeaturized", nameof(EstateData.ZipCode)))
                    .Append(mlContext.Transforms.Text.FeaturizeText("StateFeaturized", nameof(EstateData.State)))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(EstateData.Bedrooms), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(EstateData.Bathrooms), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(EstateData.LandSize), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(EstateData.HouseSize), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Concatenate("Features", "StreetFeaturized", "CityFeaturized", "ZipCodeFeaturized", "StateFeaturized", nameof(EstateData.Bedrooms), nameof(EstateData.Bathrooms), nameof(EstateData.LandSize), nameof(EstateData.HouseSize)))
                    .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(EstateData.Price), maximumNumberOfIterations: 100));

            // Train the model
            model = pipeline.Fit(trainingData);

            // Evaluate the model
            var predictions = model.Transform(testData);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(EstateData.Price));

            return metrics;
        }
        public RegressionMetrics EvaluateModel()
        {
            // Evaluate the model using the test data
            var predictions = model.Transform(testData);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(EstateData.Price));

            return metrics;
            //Console.WriteLine($"R^2: {metrics.RSquared}");
            //Console.WriteLine($"Mean Absolute Error: {metrics.MeanAbsoluteError}");
            //Console.WriteLine($"Root Mean Squared Error: {metrics.RootMeanSquaredError}");
        }
        //public void Test()
        //{
        //    // Evaluate the model
        //    var predictions = model.Transform(testData);
        //    var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: "Label", scoreColumnName: "Score");

        //    Console.WriteLine($"R^2: {metrics.MeanAbsoluteError}");
        //    Console.WriteLine($"RMSE: {metrics.RootMeanSquaredError}");
        //}
        public float Predict(EstateData estateData)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<EstateData, EstatePricePrediction>(model);
            var prediction = predictionEngine.Predict(estateData);
            return prediction.Price;
        }
    }
}
