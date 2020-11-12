using System;
using System.Linq;
using Masiv.PruebaCleanCode.DAL;
using Masiv.PruebaCleanCode.Entities;
using Masiv.PruebaCleanCode.Entities.Database;
using Microsoft.AspNetCore.Mvc;

namespace Masiv.PruebaCleanCode.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouletteController : ControllerBase
    {
        private readonly RouletteDAL _rouletteDal;
        private readonly BetDAL _betDal;

        public RouletteController(RouletteDAL rouletteDal, BetDAL betDal)
        {
            _rouletteDal = rouletteDal;
            _betDal = betDal;
        }

        [HttpGet]
        public string Index()
        {
            return "Hello World!";
        }

        [Route("[action]")]
        [HttpGet]
        public object CreateRoulette()
        {
            var vInput = new RouletteEntity
            {
                State = Constant.Created,
                Date = DateTime.UtcNow.ToString("O")
            };
            var vRoulette = _rouletteDal.Create(vInput);
            var vResult = new
            {
                vRoulette.Id
            };
            return vResult;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public object OpenRoulette(string id)
        {
            var vResult = Constant.Denied;
            try
            {
                var vRoulette = _rouletteDal.Get(id);
                if (Constant.Created.Equals(vRoulette.State, Constant.IgnoreCase))
                {
                    vRoulette.State = Constant.Opened;
                    _rouletteDal.Update(id, vRoulette);
                    vResult = Constant.Successful;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return vResult;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public object CloseRoulette(string id)
        {
            object vResult = Constant.Denied;
            try
            {
                var vRoulette = _rouletteDal.Get(id);
                if (!Constant.Opened.Equals(vRoulette.State, Constant.IgnoreCase)) return Constant.Denied;
                var vWinner = new Random().Next(0, 37);
                var vColor = vWinner % 2 == 0 ? Constant.Red : Constant.Black;
                var vBet = _betDal.Get(id);
                var vWinnerNumber = vBet.Where(x => x.Number == vWinner).ToList();
                var vWinnerColor = vBet.Where(x => vColor.Equals(x.Color)).ToList();
                vWinnerNumber.ForEach(x => x.Amount *= (decimal)Constant.WinNumber);
                vWinnerColor.ForEach(x => x.Amount *= (decimal)Constant.WinColor);
                vResult = new
                {
                    WinValue = vWinner,
                    WinnerNumber = vWinnerNumber,
                    WinnerColor = vWinnerColor,
                    Players = vBet
                };
                vRoulette.State = Constant.Closed;
                _rouletteDal.Update(id, vRoulette);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return vResult;
        }

        [Route("[action]")]
        [HttpPost]
        public object CreateBet(BetEntity pInput)
        {
            try
            {
                var vUserId = Request.Headers["UserId"].ToString();
                if (string.IsNullOrWhiteSpace(vUserId)) return Constant.Denied;
                var vRoulette = _rouletteDal.Get(pInput.RouletteId);
                if (!Constant.Opened.Equals(vRoulette.State, Constant.IgnoreCase)) return Constant.Denied;
                if (!(pInput.Number >= Constant.MinValue && pInput.Number <= Constant.MaxNumber || Constant.LstColor.Contains(pInput.Color))) return Constant.Denied;
                if (!(pInput.Amount > Constant.MinValue && pInput.Amount <= Constant.MaxAmount)) return Constant.Denied;
                pInput.UserId = vUserId;
                _betDal.Create(pInput);

                return Constant.Successful;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Constant.Denied;
            }
        }

        [Route("[action]")]
        [HttpGet]
        public object ListRoulette()
        {
            var vResult = _rouletteDal.Get();
            return vResult;
        }
    }
}
