﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Popcorn.Models.Genres;
using Popcorn.Models.Shows;
using Popcorn.Models.User;

namespace Popcorn.Services.Shows.Show
{
    public interface IShowService
    {
        /// <summary>
        /// Change the culture of TMDb
        /// </summary>
        /// <param name="language">Language to set</param>
        void ChangeTmdbLanguage(Language language);

        /// <summary>
        /// Get show by its Imdb code
        /// </summary>
        /// <param name="imdbId">Show's Imdb code</param>
        /// <returns>The show</returns>
        Task<ShowJson> GetShowAsync(string imdbId);

        /// <summary>
        /// Get show light by its Imdb code
        /// </summary>
        /// <param name="imdbId">Show's Imdb code</param>
        /// <returns>The show</returns>
        Task<ShowLightJson> GetShowLightAsync(string imdbId);

        /// <summary>
        /// Get popular shows by page
        /// </summary>
        /// <param name="page">Page to return</param>
        /// <param name="limit">The maximum number of shows to return</param>
        /// <param name="ct">Cancellation token</param>
        /// <param name="genre">The genre to filter</param>
        /// <param name="sortBy">The sort</param>
        /// <param name="ratingFilter">Used to filter by rating</param>
        /// <returns>Popular shows and the number of shows found</returns>
        Task<(IEnumerable<ShowLightJson> shows, int nbShows)> GetShowsAsync(int page,
            int limit,
            double ratingFilter,
            string sortBy,
            CancellationToken ct,
            GenreJson genre = null);

        /// <summary>
        /// Search shows by criteria
        /// </summary>
        /// <param name="criteria">Criteria used for search</param>
        /// <param name="page">Page to return</param>
        /// <param name="limit">The maximum number of movies to return</param>
        /// <param name="genre">The genre to filter</param>
        /// <param name="ratingFilter">Used to filter by rating</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Searched shows and the number of movies found</returns>
        Task<(IEnumerable<ShowLightJson> shows, int nbShows)> SearchShowsAsync(string criteria,
            int page,
            int limit,
            GenreJson genre,
            double ratingFilter,
            CancellationToken ct);

        /// <summary>
        /// Get the youtube trailer of a show
        /// </summary>
        /// <param name="show">The show</param>
        /// <param name="ct">Used to cancel loading trailer</param>
        /// <returns>Video trailer</returns>
        Task<string> GetShowTrailerAsync(ShowJson show, CancellationToken ct);
    }
}
