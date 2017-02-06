using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DeutschAktiv.Core.Models
{
    public class DataSeeder
    {
        private readonly DataContext _context;

        public DataSeeder(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            SeedClubs();
        }

        private void SeedClubs()
        {
            if (!_context.Clubs.Any())
            {
                _context.Clubs.AddRange(
                    new Club
                    {
                        Title = "",
                        Subtitle = "",
                        Summary = "",
                        LinkUrl = "",
                        ImageUrl = "",
                        IconClass = "",
                        Enabled = true,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Description = "",
                    }

                );

                _context.SaveChanges();
            }
        }
    }
}

//Club(1, "Разговорный клуб", Some("Надоело затянувшееся молчание? Присоединяйтесь!"), None, Some(routes.EducationController.listClubs().url), Some("fa fa-comments")),
//Club(2, "Экскурсии", Some("Загородные поездки и практика языка."), None, Some(routes.EducationController.listClubs().url), Some("fa fa-bus")),
//Club(3, "Киноклуб", Some("Смотрим и обсуждаем фильмы на немецком языке."), None, Some(routes.EducationController.listClubs().url), Some("fa fa-video-camera")),
//Club(4, "Мастер-классы", Some("Раскрываем секреты немецкого языка вместе!"), None, Some(routes.EducationController.listMasterClasses().url), Some("fa fa-bullhorn"))
