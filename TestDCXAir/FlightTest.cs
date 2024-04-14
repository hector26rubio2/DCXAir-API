using Application.DTOs;
using Application.Services.Interface;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using WebAPI.Helpers;

namespace TestDCXAir
{
    public class FlightTest
    {
        [Fact]
        public async Task GetOriginAirports_ReturnsOk_WithOriginAirports()
        {

            var flightServiceMock = new Mock<IFlightService>();
            var originAirports = new List<string> { "BOG", "BCN", "PEI", "JFK", "MZL", "MAD" };
            flightServiceMock.Setup(service => service.GetOriginAirportsAsync())
                             .ReturnsAsync(originAirports);

            var controller = new FlightController(flightServiceMock.Object);


            var result = await controller.GetOriginAirports();


            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<List<string>>>(okResult.Value);
            Assert.Equal("Origin airports retrieved successfully.", apiResponse.Message);
            Assert.Equal(originAirports, apiResponse.Data);
        }


        [Fact]
        public async Task GetDestinationAirports_ReturnsOk_WithDestinationAirports()
        {

            var flightServiceMock = new Mock<IFlightService>();
            var destinationAirports = new List<string> { "PEI", "BOG", "MZL", "BCN", "MAD", "JFK" };
            flightServiceMock.Setup(service => service.GetDestinationAirportsAsync())
                             .ReturnsAsync(destinationAirports);

            var controller = new FlightController(flightServiceMock.Object);


            var result = await controller.GetDestinationAirports();


            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<List<string>>>(okResult.Value);
            Assert.Equal("Destination airports retrieved successfully.", apiResponse.Message);
            Assert.Equal(destinationAirports, apiResponse.Data);
        }

        [Fact]
        public async Task GetFlightsByType_ReturnsOk_WithJourneys()
        {
     
            var flightServiceMock = new Mock<IFlightService>();

        
            var expectedJourneys = new List<JourneyDto>
            {
                new JourneyDto
                {
                    Origin = "MZL",
                    Destination = "BOG",
                    Price = 1660,
                    Flights = new List<FlightDto>
                    {
                        new FlightDto
                        {
                            Origin = "MZL",
                            Destination = "PEI",
                            Price = 830,
                            Transport = new TransportDto
                            {
                                FlightCarrier = "AV",
                                FlightNumber = "8030"
                            }
                        },
                        new FlightDto
                        {
                            Origin = "PEI",
                            Destination = "BOG",
                            Price = 830,
                            Transport = new TransportDto
                            {
                                FlightCarrier = "AV",
                                FlightNumber = "8040"
                            }
                        }
                    }
                },
                new JourneyDto
                {
                    Origin = "MZL",
                    Destination = "BOG",
                    Price = 830,
                    Flights = new List<FlightDto>
                    {
                        new FlightDto
                        {
                            Origin = "MZL",
                            Destination = "BOG",
                            Price = 830,
                            Transport = new TransportDto
                            {
                                FlightCarrier = "AV",
                                FlightNumber = "8020"
                            }
                        }
                    }
                }
            };

            // Configura el servicio simulado para devolver los datos esperados
            var filter = new FilterDto
            {
                Origin = "MZL",
                Destination = "BOG",
                CurrencyType = (CurrencyType)1,
                FlightType = FlightType.ONE_WAY
            };
            flightServiceMock.Setup(service => service.GetFlightsByTypeAsync(filter))
                             .ReturnsAsync(expectedJourneys);

            var controller = new FlightController(flightServiceMock.Object);

          
            var result = await controller.GetFlightsByType(filter);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<List<JourneyDto>>>(okResult.Value);
            Assert.Equal("Flights retrieved successfully.", apiResponse.Message);
            Assert.Equal(expectedJourneys, apiResponse.Data);
        }

    }
}