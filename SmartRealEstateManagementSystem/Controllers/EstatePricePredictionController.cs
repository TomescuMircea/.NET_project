using Application.AIML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.Data;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatePricePredictionController : ControllerBase
    {
        private readonly EstatePricePredictionModel estatePricePredictionModel;
        public EstatePricePredictionController()
        {
            estatePricePredictionModel = new EstatePricePredictionModel();
        }
        [HttpPost("train")]
        public ActionResult<RegressionMetrics> TrainModel([FromBody] bool retrain)
        {
            var data = EstateDataParser.GetEstates();
            return estatePricePredictionModel.Train(data,retrain);
            //return Ok();
        }
        [HttpPost("predict")]
        public ActionResult<float> PredictPrice(EstateData estateData)
        {
            return estatePricePredictionModel.Predict(estateData);
        }
    }
}
