using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Tests.Services
{
    [TestFixture]
    public class VideoGameCharacterServiceTests
    {
        private AppDbContext _context = null!;
        private VideoGameCharacterService _service = null!;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _service = new VideoGameCharacterService(_context);
        }

        [TearDown]
        public void TearDown() => _context.Dispose();

        [Test]
        public async Task AddCharacterAsync_ValidInput_ReturnsCharacterWithGeneratedId()
        {
            var dto = new CreateCharacterDto { Name = "Link", Game = "Zelda", Role = "Hero" };

            var result = await _service.AddCharacterAsync(dto);

            Assert.That(result.Id, Is.GreaterThan(0));
            Assert.That(result.Name, Is.EqualTo("Link"));
        }

        [Test]
        public async Task GetCharacterByIdAsync_IdNotFound_ReturnsNull()
        {
            var result = await _service.GetCharacterByIdAsync(999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetCharacterByIdAsync_ExistingId_ReturnsCorrectCharacter()
        {
            var character = new Character { Name = "Mario", Game = "Super Mario", Role = "Plumber" };
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            var result = await _service.GetCharacterByIdAsync(character.Id);
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Id, Is.EqualTo(character.Id));
            Assert.That(result.Name, Is.EqualTo("Mario"));
            Assert.That(result.Game, Is.EqualTo("Super Mario"));
            Assert.That(result.Role, Is.EqualTo("Plumber"));
        }
        [Test]
        public async Task GetAllCharactersAsync_ReturnsAllCharacters()
        {
            var characters = new List<Character>
            {
                new Character { Name = "Samus", Game = "Metroid", Role = "Bounty Hunter" },
                new Character { Name = "Pikachu", Game = "Pokemon", Role = "Electric Mouse" }
            };
            _context.Characters.AddRange(characters);
            await _context.SaveChangesAsync();
            var result = await _service.GetAllCharactersAsync();
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Any(c => c.Name == "Samus" && c.Game == "Metroid" && c.Role == "Bounty Hunter"), Is.True);
            Assert.That(result.Any(c => c.Name == "Pikachu" && c.Game == "Pokemon" && c.Role == "Electric Mouse"), Is.True);

        }
    }
}