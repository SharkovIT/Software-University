namespace MusicHub
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ImportDtos;
    using System;
    using System.Globalization;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            this.CreateMap<ImportWriterDto, Writer>();

            this.CreateMap<ImportProducerDto, Producer>();

            this.CreateMap<ImportAlbumDto, Album>()
              .ForMember(x => x.ReleaseDate, y => y.MapFrom(
                  x => DateTime.ParseExact(x.ReleaseDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<ImportSongDto, Song>()
                .ForMember(x => x.Duration, y => y.MapFrom(x => TimeSpan.ParseExact(x.Duration, "c", CultureInfo.InvariantCulture)))
                .ForMember(x => x.CreatedOn, y => y.MapFrom(x => DateTime.ParseExact(x.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<ImportPerformerDto, Performer>();
            this.CreateMap<ImportPerformerSongDto, SongPerformer>()
                .ForMember(t => t.SongId, y => y.MapFrom(k => k.Id));
        }
    }
}
