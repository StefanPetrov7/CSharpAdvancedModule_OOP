// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        private Performer performer;
        private Song song;
        private TimeSpan duration = new TimeSpan(0, 1, 20);

        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
            this.performer = new Performer("Stefan", "Petrov", 36);
            this.song = new Song("Budata", duration);
        }

        [Test]
        public void TestSongCtorName()
        {
            string expectedName = this.song.Name;
            Assert.AreEqual(expectedName, this.song.Name);
        }

        [Test]
        public void TestSongCtorDuration()
        {
            TimeSpan expected = this.song.Duration;
            Assert.AreEqual(expected, this.song.Duration);
        }

        [Test]
        public void TestPerformerCtor()
        {
            string  FULL_NAME = "Stefan Petrov";
            int AGE = 36;
            Assert.AreEqual(FULL_NAME, this.performer.FullName);
            Assert.AreEqual(AGE, this.performer.Age);
        }


        [Test]  // Test stage ctor
        public void TestStagePrformersCountToBeZero()
        {
            int expected = 0;
            Assert.AreEqual(expected, stage.Performers.Count);
        }

        [Test]  // Test stage ctor
        public void StageIsNotNull()
        {
            Assert.IsNotNull(stage);
        }

        [Test]
        public void WhenAddingPErformerCountShouldBeOne()
        {
            int expected = 1;
            this.stage.AddPerformer(this.performer);
            Assert.AreEqual(expected, stage.Performers.Count);
        }

        [Test]
        public void WhenAddingPerformerShouldThrowExceptionInvalidAge()
        {
            this.performer = new Performer("Stefan", "Petrov", 17);
            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(performer));
        }

        [Test]
        public void WhenAddingPerformerShouldThrowNullException()
        {
            this.performer = null;
            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(performer));
        }

        [Test]
        public void AddSongShouldThrowNullException()
        {
            this.song = null;
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(song));
        }

        [Test]
        public void AddSongShouldThrowExceptionForDuration()
        {
            this.song = new Song("Budata", new TimeSpan(0, 0, 59));
            Assert.Throws<ArgumentException>(() => this.stage.AddSong(song));
        }

        [Test]
        public void AddingSongToPerformerSouldReturnCorrectCount()
        {
            int expectedCount = 1;
            this.song = new Song("Budata", new TimeSpan(0, 1, 0));
            this.stage.AddSong(this.song);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
            Assert.AreEqual(expectedCount, this.performer.SongList.Count);
        }

        [Test]
        public void GetPerformerShouldThrowException()
        {
            string wrongName = "wrong name";
            this.song = new Song("Budata", new TimeSpan(0, 1, 0));
            this.stage.AddSong(this.song);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
            Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(this.song.Name, wrongName));
        }

        [Test]
        public void GetSongShouldThrowException()
        {
            string wrongName = "wrong name";
            this.song = new Song("Budata", new TimeSpan(0, 1, 0));
            this.stage.AddSong(this.song);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
            Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(wrongName, this.performer.FullName));
        }

        [Test]
        public void PlayShouldReturnCorrectString()
        {
            Song songOne = new Song("One", new TimeSpan(0, 1, 0));
            Song songTwo = new Song("Two", new TimeSpan(0, 1, 0));
            this.stage.AddSong(songOne);
            this.stage.AddSong(songTwo);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(songOne.Name, this.performer.FullName);
            this.stage.AddSongToPerformer(songTwo.Name, this.performer.FullName);
            Assert.AreEqual("1 performers played 2 songs", this.stage.Play());
        }

    }
}