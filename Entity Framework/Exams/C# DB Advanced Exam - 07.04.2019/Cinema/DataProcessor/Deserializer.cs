namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var sb = new StringBuilder();

            var validMovies = new List<Movie>();

            foreach (var movieDto in moviesDto)
            {
                var movieExists = context.Movies.Any(m => m.Title == movieDto.Title);
                var isValidDto = IsValid(movieDto);
                var parseEnum = Enum.TryParse(movieDto.Genre, out Genre genreResult);
                
                if (movieExists || !isValidDto || !parseEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = Mapper.Map<Movie>(movieDto);
                validMovies.Add(movie);

                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}