using eTickets.Models;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Cinemas
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "Nothing",
                            Description = "This is Description"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "Nothing",
                            Description = "This is the Description"
                        }
                    });

                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio",
                            ProfilePictureURL = "Nothing"
                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio",
                            ProfilePictureURL = "Nothing"
                        }
                    });

                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio",
                            ProfilePictureURL = "Nothing"
                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio",
                            ProfilePictureURL = "Nothing"
                        }
                    });

                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Movie 1",
                            Description = "This is the Description",
                            Price = 39.50,
                            ImageURL = "Nothing",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Movie 2",
                            Description = "This is the Description",
                            Price = 39.50,
                            ImageURL = "Nothing",
                            StartDate= DateTime.Now.AddDays(-10),
                            EndDate= DateTime.Now.AddDays(-2),
                            CinemaId = 2,
                            ProducerId= 2,
                            MovieCategory = MovieCategory.Horror
                        }
                    });

                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3,
                        },
                        new Actor_Movie()
                        {
                            ActorId= 2,
                            MovieId = 4,
                        },
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3,
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
