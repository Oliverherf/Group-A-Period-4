using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Don2Loot
{
    public class Database
    {
        char[] specialCharacters = {',', '<', '.', '>', ';', ':', '\'', '"', '{', '{', ']', '}', '\\',
            '|', '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+'};
        char[] specialCharactersForEmail = {',', '<', '>', ';', ':', '\'', '"', '{', '{', ']', '}', '\\',
            '|', '`', '~', '!', '#', '$', '%', '^', '&', '*', '(', ')', '='};
        private readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>();
            _database.CreateTableAsync<Task>();
            _database.CreateTableAsync<Chest>();
            _database.CreateTableAsync<Reward>();
        }

        //Gets a list of all database entries from all tables
        public Task<List<User>> getUser()
        {
            return _database.Table<User>().ToListAsync();
        }
        public Task<List<Task>> getTask()
        {
            return _database.Table<Task>().ToListAsync();
        }
        public Task<List<Chest>> getChest()
        {
            return _database.Table<Chest>().ToListAsync();
        }
        public Task<List<Reward>> getReward()
        {
            return _database.Table<Reward>().ToListAsync();
        }


        //Adding fields to database
        public Task<int> saveUser(User user)
        {
            User user2 = new User();
            user2.UserName = user.UserName.Trim(specialCharacters);
            user2.UserEmail = user.UserEmail.Trim(specialCharactersForEmail);
            user2.UserSignature = user.UserSignature.Trim(specialCharacters);
            user2.UserCoins = user.UserCoins;
            user2.UserStreak = user.UserStreak;
            return _database.InsertAsync(user2);
        }
        public Task<int> saveTask(Task task)
        {
            return _database.InsertAsync(task);
        }
        public Task<int> saveChest(Chest chest)
        {
            return _database.InsertAsync(chest);
        }
        public Task<int> saveReward(Reward reward)
        {
            return _database.InsertAsync(reward);
        }

        //Update specific fields of the user table from a specific user based on the PK
        public Task<int> updateUserName(string PK, string newUserName)
        {
            newUserName = newUserName.Trim(specialCharacters);
            return _database.ExecuteAsync("UPDATE User SET username = ? WHERE useremail = ?", newUserName, PK);
        }
        public Task<int> updateUserSignature(string PK, string newUserSignature)
        {
            newUserSignature = newUserSignature.Trim(specialCharacters);
            return _database.ExecuteAsync("UPDATE User SET usersignature = ? WHERE useremail = ?", newUserSignature, PK);
        }
        public Task<int> updateUserStreak(string PK, int newUserStreak)
        {
            return _database.ExecuteAsync("UPDATE User SET userstreak = ? WHERE useremail = ?", newUserStreak, PK);
        }
        public Task<int> updateUserCoins(string PK, int newUserCoins)
        {
            return _database.ExecuteAsync("UPDATE User SET usercoins = ? WHERE useremail = ?", newUserCoins, PK);
        }

        //Update specific fields of the tasks table from a specific task based on the PK
        public Task<int> updateTaskName(int PK, string newTaskName)
        {
            newTaskName = newTaskName.Trim(specialCharacters);
            return _database.ExecuteAsync("UPDATE Task SET taskname = ? WHERE id = ?", newTaskName, PK);
        }
        public Task<int> updateTaskDescription(int PK, string newTaskDescription)
        {
            newTaskDescription = newTaskDescription.Trim(specialCharacters);
            return _database.ExecuteAsync("UPDATE Task SET taskdescription = ? WHERE id = ?", newTaskDescription, PK);
        }
        public Task<int> updateTaskDeadline(int PK, DateTime newTaskDeadline)
        {
            return _database.ExecuteAsync("UPDATE Task SET taskdeadline = ? WHERE id = ?", newTaskDeadline, PK);
        }
        public Task<int> updateTaskIsFinished(int PK, bool newTaskIsFinished)
        {
            return _database.ExecuteAsync("UPDATE Task SET isfinished = ? WHERE id = ?", newTaskIsFinished, PK);
        }

        //Update specific fields of the Chest table from a specific chest based on the PK
        public Task<int> updateChestPrice(string PK, int newChestPrice)
        {
            return _database.ExecuteAsync("UPDATE Chest SET chestPrice = ? WHERE chestname = ?", PK, newChestPrice);
        }

        //Update specific fields of the Reward table from a specific chest based on the PK
        public Task<int> updateRewardIsUnlocked(int PK, bool newRewardIsUnlocked)
        {
            return _database.ExecuteAsync("UPDATE Reward SET isunlocked = ? WHERE rewardid = ?", PK, newRewardIsUnlocked);
        }
        public Task<int> updateRewardImage(int PK, string newRewardImage)
        {
            newRewardImage = newRewardImage.Trim(specialCharacters);
            return _database.ExecuteAsync("UPDATE Reward SET rewardimage = ? WHERE rewardid = ?", PK, newRewardImage);
        }
        public Task<int> updateRewardRarity(int PK, string newRewardRarity)
        {
            newRewardRarity = newRewardRarity.Trim(specialCharacters);
            return _database.ExecuteAsync("UPDATE Reward SET rewardrarity = ? WHERE rewardid = ?", PK, newRewardRarity);
        }
        public Task<int> updateRewardName(int PK, string newRewardName)
        {
            newRewardName = newRewardName.Trim(specialCharacters);
            return _database.ExecuteAsync("UPDATE Reward SET rewardname = ? WHERE rewardid = ?", PK, newRewardName);
        }
        public Task<int> updateRewardDropChance(int PK, string newRewardDropChance)
        {
            newRewardDropChance = newRewardDropChance.Trim(specialCharacters);
            return _database.ExecuteAsync("UPDATE Reward SET isunlocked = ? WHERE rewardid = ?", PK, newRewardDropChance);
        }

        //Delete Tables from database
        public Task<int> deleteUser(User user)
        {
            return _database.ExecuteAsync("DELETE FROM User WHERE useremail = ?", user.UserEmail);
        }
        public Task<int> deleteTask(Task task)
        {
            return _database.ExecuteAsync("DELETE FROM User WHERE useremail = ?", task.Id);
        }
        public Task<int> deleteReward(Reward reward)
        {
            return _database.ExecuteAsync("DELETE FROM User WHERE useremail = ?", reward.RewardId);
        }
        public Task<int> deleteChest(Chest chest)
        {
            return _database.ExecuteAsync("DELETE FROM User WHERE useremail = ?", chest.ChestName);
        }
    }

    //Creation of the database
    [Table("User")]
    public class User
    {
        [PrimaryKey]
        [Column("useremail")]
        [NotNull]
        public string UserEmail { get; set; }

        [Column("username")]
        [NotNull]
        public string UserName { get; set; }

        [Column("usersignature")]
        [NotNull]
        public string UserSignature { get; set; }

        [Column("userstreak")]
        public int UserStreak { get; set; }

        [Column("userCoins")]
        public int UserCoins { get; set; }
    }

    [Table("Task")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("taskname")]
        [NotNull]
        public string TaskName { get; set; }

        [Column("taskdescription")]
        [NotNull]
        public string TaskDescription { get; set; }

        [Column("taskdeadline")]
        [NotNull]
        public DateTime TaskDeadline { get; set; }

        [Column("isfinished")]
        public bool IsFinished { get; set; }

        [Column("useremail")]
        [ForeignKey(typeof(User))]
        public string UserEmail { get; set; }
    }

    [Table("Chest")]
    public class Chest
    {
        [PrimaryKey, AutoIncrement]
        [Column("chestname")]
        [NotNull]
        public string ChestName { get; set; }

        [Column("chestprice")]
        [NotNull]
        public int ChestPrice { get; set; }
    }

    [Table("Reward")]
    public class Reward
    {
        [PrimaryKey, AutoIncrement]
        [Column("rewardid")]
        public int RewardId { get; set; }

        [Column("isunlocked")]
        [NotNull]
        public bool isUnlocked { get; set; }

        [Column("rewardimage")]
        [NotNull]
        public string RewardImage { get; set; }

        [Column("rewardrarity")]
        [NotNull]
        public string RewardRarity { get; set; }

        [Column("chestname")]
        [ForeignKey(typeof(Chest))]
        [NotNull]
        public string ChestName { get; set; }

        [Column("rewardname")]
        [NotNull]
        public string RewardName { get; set; }
    }
}