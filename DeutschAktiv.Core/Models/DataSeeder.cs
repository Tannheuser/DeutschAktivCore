﻿using System;
using System.Linq;
using System.Security.Claims;
using DeutschAktiv.Core.Constant;
using Microsoft.AspNetCore.Identity;

namespace DeutschAktiv.Core.Models
{
    public class DataSeeder
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Seed()
        {
            SeedClubs();
            SeedCourses();
            SeedSchedule();
            SeedUsers();
        }

        private void SeedUsers()
        {
            var user = _userManager.FindByNameAsync("admin");
            user.Wait();

            if (user.Result == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin"
                };

                _userManager.CreateAsync(admin, "aXw52zg!").Wait();
                _userManager.AddClaimAsync(admin, new Claim("CanUpdate", "true")).Wait();
                _userManager.AddClaimAsync(admin, new Claim("CanDelete", "true")).Wait();

            }
        }

        private void SeedClubs()
        {
            if (!_context.Clubs.Any())
            {
                _context.Clubs.AddRange(
                    new Club
                    {
                        Title = "Разговорный клуб",
                        Subtitle = "Тематические дискуссии с носителями языка",
                        Summary = "Надоело затянувшееся молчание? Присоединяйтесь!",
                        Controller = "Club",
                        Action = "GetClubs",
                        ImageUrl = "/img/clubs/speak.jpg",
                        IconClass = "fa fa-comments",
                        Enabled = true,
                        Type = ClubType.Club,
                        Description = @"<p>Каждую пятницу мы организуем встречу клуба. Это прекрасная возможность общаться на немецком языке с носителем и сломать языковой барьер, познакомиться с интересными людьми и перевести свой пассивный словарный запас в активный.<br/></p><p>Если вы хотите не только изучать немецкий, но и одновременно весело и активно проводить время, то эта группа для вас!<br/>Здесь нет скучных учебников и домашних заданий, занудной грамматики и зубрежки. Мы собираемся вместе, чтобы говорить на немецком языке, слушать и понимать всё лучше и лучше. Мы обсуждаем темы, события, играем в игры и разгадываем загадки. Мы пьем чай и едим сладости, рассказываем о себе и делимся мнениями, и, конечно, шутим и смеемся.<br/></p><p>Наш разговорный клуб дает практику общения немецкого языка, помогает преодолеть языковой барьер и совершенствовать разговорную речь, поддерживать уровень знаний немецкого языка. Вы учитесь слушать и понимать немецкую речь, изучаете языковые особенности, приобретаете новые знания и увеличиваете свой словарный запас.<br/>Ведущие нашего клуба – интересные и харизматичные носители языка из Германии!</p>"
                    },
                    new Club
                    {
                        Title = "Экскурсии",
                        Subtitle = "Загородные поездки и общение на немецком языке",
                        Summary = "Загородные поездки и практика языка.",
                        Controller = "Club",
                        Action = "GetClubs",
                        ImageUrl = "/img/clubs/excursion.jpg",
                        IconClass = "fa fa-bus",
                        Enabled = true,
                        Type = ClubType.Club,
                        Description = @"
                        <p>
                            Кто не любит прогулки по городу, да к тому же выезды на природу в Подмосковье и другие города?
                            Чтобы сделать поездку интересной, полезной и познавательной Deutsch Aktiv организует экскурсии на немецком языке!
                        </p>
                        <p>
                            Мы гуляем по городу в сопровождении гидов, рассказывающих о достопримечательностях на немецком языке.
                            Также выезжаем на выходные в такие города, как Суздаль, Владимир и другие.
                            Вы получаете возможность провести время в дружной компании, интересующейся языком, а также попрактиковать свои навыки говорения.
                        </p>
                        <p>
                            А на двухдневных языковых погружениях в пансионате под городом Троицк всех ждет увлекательная программа с носителем языка из Германии:
                            совместные групповые экскурсии, занятия спортом на немецком, в том числе настольным теннисом, посиделки вечером на веранде за чашкой чая за непринужденной беседой на немецком -
                            и все это в перерывах между интенсивным языковым обучением!
                        </p>
                        <p>
                            Все подробности о наборе групп на выездные экскурсии по телефону 8-903-536-60-56.
                        </p>".Trim().Replace(Environment.NewLine, string.Empty)
                    },
                    new Club
                    {
                        Title = "Киноклуб",
                        Subtitle = "Смотрим фильмы на немецком языке",
                        Summary = "Смотрим и обсуждаем фильмы на немецком языке.",
                        Controller = "Club",
                        Action = "GetClubs",
                        ImageUrl = "/img/clubs/film.jpg",
                        IconClass = "fa fa-video-camera",
                        Enabled = true,
                        Type = ClubType.Club,
                        Description = @"
                        <p>
                            Благодаря просмотру кинокартин в нашем клубе вы научитесь воспринимать немецкий язык на слух,
                            расширите свой словарный запас и приятно проведете время в дружеской обстановке.
                        </p>
                        <p>
                            Не секрет, что просмотр кинофильмов на изучаемом языке является хорошим подспорьем в обучении.
                            На наших киносеансах мы устраиваем просмотры как классических фильмов на немецком языке, так и следим за новинками.
                            Мы не только наслаждаемся происходящим на экране, но и разбираем нужные и интересные слова и фразы из кинофильмов,
                            ну и, конечно, делимся своими впечатлениями после просмотра, конечно, все происходит на немецком и часто в окружении носителей языка!
                        </p>".Trim().Replace(Environment.NewLine, string.Empty)
                    },
                    new Club
                    {
                        Title = "Мастер-классы",
                        Subtitle = "Deutsch Aktiv представляет новый формат встреч на немецком языке",
                        Summary = "Раскрываем секреты немецкого языка вместе!",
                        Controller = "Club",
                        Action = "GetMasterClasses",
                        ImageUrl = "/img/clubs/masterbw.jpg",
                        IconClass = "fa fa-bullhorn",
                        Enabled = true,
                        Price = 700,
                        Type = ClubType.MasterClass,
                        Description = @"
                        <p>
                            Мы проводим Мастер-классы по актуальным темам для всех, кто связан с немецким языком!
                        </p>
                        <p>
                            Теперь каждую вторую СУББОТУ с 15.00 до 17.00 мы приглашаем Вас на двухчасовой мастер-класс по определенной теме - от тем по грамматике до бизнес-тренингов на немецком языке!
                            Дополнительно во время кофе-паузы у Вас есть возможность пообщаться с ведущим мастер-класса и участниками в неформальной обстановке.
                            Также предусмотрены дополнительные 30 минут после семинара для ответов модератора на вопросы участников.
                        </p>
                        <p>
                            Ведущими мастер-классов являются профессионалы своего дела из разных стран, как носители немецкого языка из Германии, Австрии, так и специалисты в сфере немецкого языка из России.
                            Мастер-класс - это отличная возможность не только улучшить свои знания языка по определенной теме, но и найти единомышленников и новых друзей!
                        </p>".Trim().Replace(Environment.NewLine, string.Empty)
                    }

                );

                _context.SaveChanges();
            }
        }

        private void SeedCourses()
        {
            if (!_context.Courses.Any())
            {
                _context.Courses.AddRange(
                    new Course
                    {
                        Title = "A1 утро",
                        Price = 6900,
                        Day = "Понедельник - Среда<br/>Вторник - Четверг",
                        Time = "9:00-10:30",
                        Level = "low",
                        Enabled = true
                    },
                    new Course
                    {
                        Title = "A1 вечер",
                        Price = 6900,
                        Day = "Понедельник - Среда<br/>Вторник - Четверг",
                        Time = "19:00-20:30",
                        Level = "low",
                        Enabled = true
                    },
                    new Course
                    {
                        Title = "A2 утро",
                        Price = 6900,
                        Day = "Понедельник - Среда<br/>Вторник - Четверг",
                        Time = "9:00-10:30",
                        Level = "low",
                        Enabled = true
                    },
                    new Course
                    {
                        Title = "A2 вечер",
                        Price = 6900,
                        Day = "Понедельник - Среда<br/>Вторник - Четверг",
                        Time = "19:00-20:30",
                        Level = "low",
                        Enabled = true
                    },
                    new Course
                    {
                        Title = "B1",
                        Price = 6900,
                        Day = "Понедельник - Четверг",
                        Time = "19:00-20:30",
                        Level = "middle",
                        Enabled = true
                    },
                    new Course
                    {
                        Title = "B2",
                        Price = 6900,
                        Day = "Понедельник - Четверг",
                        Time = "19:00-20:30",
                        Level = "middle",
                        Enabled = true
                    },
                    new Course
                    {
                        Title = "C1",
                        Price = 6900,
                        Day = "Понедельник - Четверг",
                        Time = "19:00-20:30",
                        Level = "high",
                        Enabled = true
                    },
                    new Course
                    {
                        Title = "Интенсивный",
                        Subtitle = "(все уровни)",
                        Price = 13300,
                        Day = "Суббота - Воскресенье",
                        Time = "12:00-15:30",
                        Level = "custom",
                        Enabled = true
                    }

                );

                _context.SaveChanges();
            }
        }

        private void SeedSchedule()
        {
            if (!_context.Schedule.Any())
            {
                _context.Schedule.AddRange(
                    new ScheduleItem
                    {
                        Title = "Разговорный клуб",
                        Subtitle = "все уровни",
                        Day = "каждую пятницу",
                        Time = "19:00 - 21:00",
                        Price = 350,
                        Place = "Лубянка",
                        Teacher = "носитель",
                        Date = new DateTime(2017, 2, 24),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Разговорный клуб",
                        Subtitle = "все уровни",
                        Day = "каждую пятницу",
                        Time = "19:00 - 21:00",
                        Price = 350,
                        Place = "Лубянка",
                        Teacher = "носитель",
                        Date = new DateTime(2017, 3, 3),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Разговорный клуб",
                        Subtitle = "все уровни",
                        Day = "каждую пятницу",
                        Time = "19:00 - 21:00",
                        Price = 350,
                        Place = "Лубянка",
                        Teacher = "носитель",
                        Date = new DateTime(2017, 3, 10),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Разговорный клуб",
                        Subtitle = "все уровни",
                        Day = "каждую пятницу",
                        Time = "19:00 - 21:00",
                        Price = 350,
                        Place = "Лубянка",
                        Teacher = "носитель",
                        Date = new DateTime(2017, 3, 17),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Разговорный клуб",
                        Subtitle = "все уровни",
                        Day = "каждую пятницу",
                        Time = "19:00 - 21:00",
                        Price = 350,
                        Place = "Лубянка",
                        Teacher = "носитель",
                        Date = new DateTime(2017, 3, 24),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Разговорный клуб",
                        Subtitle = "все уровни",
                        Day = "каждую пятницу",
                        Time = "19:00 - 21:00",
                        Price = 350,
                        Place = "Лубянка",
                        Teacher = "носитель",
                        Date = new DateTime(2017, 3, 31),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Мастер-класс",
                        Subtitle = "все уровни",
                        Day = "каждую вторую субботу",
                        Time = "15:00 - 17:00",
                        Price = 700,
                        Place = "Лубянка",
                        Teacher = "русскоязычный преподаватель",
                        Date = new DateTime(2017, 4, 8),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Мастер-класс",
                        Subtitle = "все уровни",
                        Day = "каждую вторую субботу",
                        Time = "15:00 - 17:00",
                        Price = 700,
                        Place = "Лубянка",
                        Teacher = "русскоязычный преподаватель",
                        Date = new DateTime(2017, 4, 22),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Мастер-класс",
                        Subtitle = "все уровни",
                        Day = "каждую вторую субботу",
                        Time = "15:00 - 17:00",
                        Price = 700,
                        Place = "Лубянка",
                        Teacher = "русскоязычный преподаватель",
                        Date = new DateTime(2017, 3, 11),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Мастер-класс",
                        Subtitle = "все уровни",
                        Day = "каждую вторую субботу",
                        Time = "15:00 - 17:00",
                        Price = 700,
                        Place = "Лубянка",
                        Teacher = "русскоязычный преподаватель",
                        Date = new DateTime(2017, 3, 25),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Мастер-класс",
                        Subtitle = "все уровни",
                        Day = "каждую вторую субботу",
                        Time = "15:00 - 17:00",
                        Price = 700,
                        Place = "Лубянка",
                        Teacher = "русскоязычный преподаватель",
                        Date = new DateTime(2017, 2, 25),
                        Enabled = true
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
