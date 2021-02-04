using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quake.Core.Repositories.Cards;
using Quake.Data.Entities;

namespace Quake.Api.Controllers
{
    [Route("api/cards")]
    public class CardController : BaseController
    {
        private readonly ICardRepository cardRepository;
        private readonly IMapper mapper;

        public CardController(
            ICardRepository cardRepository,
            IMapper mapper
        )
        {
            this.cardRepository = cardRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAll([FromQuery] string search)
        {
            var card = this.cardRepository.GetAll(search);
            return Ok(card);
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetOne(long id)
        {
            var entity = this.cardRepository.GetOne(id);
            var card = this.mapper.Map<Card>(entity);
            return Ok(card);
        }

        [HttpPost]
        public ActionResult<Card> Create(Card c)
        {
            var card = this.mapper.Map<Card>(c);
            card = this.cardRepository.Create(card);
            return this.mapper.Map<Card>(card);
        }

        [HttpPut("{id}")]
        public ActionResult<Card> Put(long id, Card c)
        {
            var card = this.cardRepository.Update(id, c);
            return Ok(card);
        }

        [HttpDelete("{id}")]
        public ActionResult<Card> Delete(long id)
        {
            this.cardRepository.Delete(id);
            return Ok();
        }
    }
}