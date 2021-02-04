using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quake.Data.Database;
using Quake.Data.Entities;

namespace Quake.Core.Repositories.Cards
{
    public interface ICardRepository : IRepository<Card> { }
    public class CardRepository : ICardRepository
    {
        private readonly QuakeContext context;
        public CardRepository(QuakeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Card> GetAll(string search)
        {
            return this.context.Cards.ToList();
        }

        public Card GetOne(long id)
        {
            return this.context.Cards.Where(c => c.Id == id).Single();
        }

        public Card Create(Card c)
        {
            this.context.Cards.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.Cards.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Card Update(long id, Card newCard)
        {
            newCard.Id = id;
            this.context.Entry(newCard).State = EntityState.Modified;
            this.context.SaveChanges();

            return newCard;
        }
    }
}