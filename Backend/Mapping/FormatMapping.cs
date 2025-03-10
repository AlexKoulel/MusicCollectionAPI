﻿using MusicCollectionAPI.Backend.DTOs.FormatDTOs;
using MusicCollectionAPI.Backend.Entities;

namespace MusicCollectionAPI.Backend.Mapping
{
    public static class FormatMapping
    {
        public static Format FormatToEntity(this CreateFormatDTO format)
        {
            return new Format()
            {
                Name = format.Name
            };
        }

        public static Format FormatToEntity(this UpdateFormatDTO format, int id)
        {
            return new Format()
            {
                Id = id,
                Name = format.Name
            };
        }

        public static FormatDTO ToDTO(this Format format)
        {
            return new FormatDTO(format.Id, format.Name);
        }
    }
}
