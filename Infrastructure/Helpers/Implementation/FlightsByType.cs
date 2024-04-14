using Domain.Entities;
using Domain.Models;
using Infrastructure.Exceptions;
using Infrastructure.Helpers.Interfaces;

namespace Infrastructure.Helpers.Implementation
{
    public class FlightsByType : IFlightsByType
    {
        private Dictionary<string, List<Flight>> adjacencyList;
        public FlightsByType() {
            adjacencyList = new Dictionary<string, List<Flight>>();
        }

        public List<Journey> GetOneWayFlights(string origin, string destination, List<Flight> flights)
        {
            BuildFlight(flights);
            List<Journey> journeys = GetJourneysForDestination(origin, destination);
            return journeys;
        }

        public List<Journey> GetRoundTripFlights(string origin, string destination, List<Flight> flights)
        {
            List<Journey> journeys = GetOneWayFlights(origin, destination, flights);
            journeys.AddRange( GetJourneysForDestination( destination, origin));
            return journeys;
        }

        private void BuildFlight(List<Flight> flights) {


            flights.ForEach((flight =>
            {
                if (!adjacencyList.ContainsKey(flight.Origin))
                {
                    adjacencyList[flight.Origin] = new List<Flight>();
                }

                adjacencyList[flight.Origin].Add(flight);
            }));

        }


        private List<Flight> GetFlights(string origin)
        {
            if (adjacencyList.ContainsKey(origin))
            {
                return adjacencyList[origin];
            }

            throw new FlightNotFoundException($"No flights found for the specified origin: {origin}");
        }

        private List<Journey> GetJourneysForDestination(string origin, string destination)
        {
            List<Journey> journeys = new List<Journey>();
            List<Flight> tempRoute = new List<Flight>();
            List<Flight> originFlights = GetFlights(origin);
            List<string> visitedFlightsNumber = new List<string>();
            double priceJourney = 0;
            originFlights.ForEach(flight =>
            {
                if (!visitedFlightsNumber.Contains(flight.Transport.FlightNumber))
                {
                    visitedFlightsNumber.Add(flight.Transport.FlightNumber);
                    tempRoute.Add(flight);
                    priceJourney += flight.Price;
                    if (flight.Destination == destination)
                    {
                        journeys.Add(new Journey(new List<Flight>(tempRoute), origin, destination, priceJourney));
                        priceJourney = 0;
                    }
                    else
                    {
                        FindJourneys(origin, flight.Origin, flight.Destination, destination, journeys, tempRoute, visitedFlightsNumber, priceJourney);
                    }
                    tempRoute.Remove(flight);
                    priceJourney = 0;
                }

            });
            if (journeys.Count == 0)
            {
                throw new JourneysNotFoundException($"No journeys found for the specified origin: {origin} and destination: {destination}");
            }
            return journeys;
        }


        private void FindJourneys(string origin, string originPreviousFlight, string actualOrigin, string destination, List<Journey> journeys, List<Flight> tempRoute, List<string> visitedFlightsNumber, double priceJourney)
        {
            List<Flight> originFlights = GetFlights(actualOrigin);

            originFlights.ForEach(flight =>
            {
                if (!visitedFlightsNumber.Contains(flight.Transport.FlightNumber) && originPreviousFlight != flight.Destination && origin != flight.Destination)
                {
                    visitedFlightsNumber.Add(flight.Transport.FlightNumber);

                    tempRoute.Add(flight);
                    priceJourney += flight.Price;
                    if (flight.Destination == destination)
                    {
                        journeys.Add(new Journey(new List<Flight>(tempRoute), origin, destination, priceJourney));

                    }
                    else
                    {
                        FindJourneys(origin, flight.Origin, flight.Destination, destination, journeys, tempRoute, visitedFlightsNumber, priceJourney);
                    }
                    priceJourney = 0;
                    tempRoute.Remove(flight);
                }

            });
        }
    }
}
