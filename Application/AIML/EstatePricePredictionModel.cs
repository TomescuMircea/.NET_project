using Microsoft.ML;
using Microsoft.ML.Data;

namespace Application.AIML
{
    public class EstatePricePredictionModel
    {
        private readonly MLContext mlContext;
        private ITransformer model;
        private IDataView testData;

        public EstatePricePredictionModel() => mlContext = new MLContext(seed: 0);

        public RegressionMetrics Train(IDataView dataView, bool retrain = false)
        {
            // Split the data into training and testing sets
            var splitData = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var trainingData = splitData.TrainSet;
            testData = splitData.TestSet;

            if (retrain == false)
            {
                model = mlContext.Model.Load("model.zip", out DataViewSchema schema);
            }
            else
            {
                var pipeline = mlContext.Transforms.Text.FeaturizeText("StreetFeaturized", nameof(EstateData.Street))
                        .Append(mlContext.Transforms.Text.FeaturizeText("CityFeaturized", nameof(EstateData.ZipCode)))
                        .Append(mlContext.Transforms.Text.FeaturizeText("StateEncoded", nameof(EstateData.State)))
                        .Append(mlContext.Transforms.Text.FeaturizeText("ZipCodeEncoded", nameof(EstateData.ZipCode)))
                        .Append(mlContext.Transforms.Conversion.ConvertType(nameof(EstateData.Bedrooms), outputKind: DataKind.Single))
                        .Append(mlContext.Transforms.Conversion.ConvertType(nameof(EstateData.Bathrooms), outputKind: DataKind.Single))
                        .Append(mlContext.Transforms.Conversion.ConvertType(nameof(EstateData.LandSize), outputKind: DataKind.Single))
                        .Append(mlContext.Transforms.Conversion.ConvertType(nameof(EstateData.HouseSize), outputKind: DataKind.Single))
                        .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(EstateData.Bedrooms)))
                        .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(EstateData.Bathrooms)))
                        .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(EstateData.LandSize)))
                        .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(EstateData.HouseSize)))
                        .Append(mlContext.Transforms.Concatenate("Features", "StreetFeaturized", 
                        "CityFeaturized", "StateEncoded", 
                        "ZipCodeEncoded", 
                        nameof(EstateData.Bedrooms), nameof(EstateData.Bathrooms), 
                        nameof(EstateData.LandSize), nameof(EstateData.HouseSize)))
                        .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(EstateData.Price),
                        featureColumnName: "Features"));

                // Train the model
                model = pipeline.Fit(trainingData);
            }

            // Evaluate the model
            var predictions = model.Transform(testData);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(EstateData.Price));

            mlContext.Model.Save(model, testData.Schema, "model.zip");
            return metrics;
        }

        public float Predict(EstateData estateData)
        {
            if ( model == null)
            {
                model = mlContext.Model.Load("model.zip", out DataViewSchema schema);
            }
            var predictionEngine = mlContext.Model.CreatePredictionEngine<EstateData, EstatePricePrediction>(model);
            var prediction = predictionEngine.Predict(estateData);
            return prediction.Price;
        }
    }
}
