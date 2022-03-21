using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL;
using WTelegram;

namespace TelegramBot
{
    public partial class Form1 : Form
    {
        //Parameters
        public class UserBase
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }


        public static string _session_pathname;
        public static Client client = null;
        public Dictionary<long, UserBase> users;
        public static readonly int SleepTime = 10;
        public bool ThreadRun = false;
        public bool SystemIsRun = false;
        //private ChatBase chatBase = null;
        private Messages_Chats allchats;








        //Form
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            //Veritabanı bağlantısı bağladı.
            Connection.sqlconnection();
            DbLoad_Setting();
        }



        string Config(string str)
        {
            switch (str)
            {
                case "api_id": return txtApiID.Text;
                case "api_hash": return txtAPiHash.Text;
                case "phone_number": return txtPhoneNum.Text;
                case "verification_code":
                    string code = null;
                    Logs("Dogrulama bekliyor.");
                    ShowInputDialog(ref code);
                    Thread.Sleep(1000);
                    return code;
                case "first_name": return "Bla";      // if sign-up is required
                case "last_name": return "Bla";          // if sign-up is required
                case "password": return "secret!";     // if user has enabled 2FA
                case "session_pathname": return _session_pathname;
                default: return null;                  // let WTelegramClient decide the default config
            }
        }

        private async Task StartingAsync()
        {


            if (string.IsNullOrWhiteSpace(txtApiID.Text))
            {
                MessageBox.Show("apiID Is Null Or White Space");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAPiHash.Text))
            {
                MessageBox.Show("APiHash Is Null Or White Space");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNum.Text))
            {
                MessageBox.Show("PhoneNum Is Null Or White Space");
                return;
            }

            _session_pathname = txtPhoneNum.Text.Replace("+", "") + ".session";


            Logs("Client Başladı.");
            client = new Client(Config);
            Logs("Client Tamamlandı.");

            Logs("Connect Başladı.");
            await client.ConnectAsync();
            Logs("Connect Tamamlandı.");

            Logs("Login Başladı.");
            await client.LoginUserIfNeeded();
            Logs("Login Tamamlandı.");

            await GET_Messages_GetAllChats();
            users = new Dictionary<long, UserBase>();
            DbLoad_Members();
            Logs("Kullanım için hazır.");

        }

        private void Logs(string Message)
        {
            txtLogs.Text += Message + Environment.NewLine;
        }

        public static int GetRandom()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 4000);
        }

        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog,
                ClientSize = size,
                Text = "AuthKey"
            };

            System.Windows.Forms.TextBox textBox = new TextBox
            {
                Size = new System.Drawing.Size(size.Width - 10, 23),
                Location = new System.Drawing.Point(5, 5),
                Text = input
            };
            inputBox.Controls.Add(textBox);

            Button okButton = new Button
            {
                DialogResult = System.Windows.Forms.DialogResult.OK,
                Name = "okButton",
                Size = new System.Drawing.Size(75, 23),
                Text = "&OK",
                Location = new System.Drawing.Point(size.Width - 80 - 80, 39)
            };
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel,
                Name = "cancelButton",
                Size = new System.Drawing.Size(75, 23),
                Text = "&Cancel",
                Location = new System.Drawing.Point(size.Width - 80, 39)
            };
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;

            return result;
        }

        //SQL İşlemleri
        private void DbLoad_Members()
        {
            if (Connection.IsOpen())
            {
                using (SQLiteCommand myCommand = new SQLiteCommand("Select * from tb_Members", Connection.baglanti))
                {
                    using (SQLiteDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long UserID = Convert.ToInt64(reader["UserID"]);
                            string UserName = reader["Name"].ToString();

                            UserBase userBase = new UserBase
                            {
                                ID = UserID.ToString(),
                                Name = UserName.ToString()
                            };
                            users.Add(UserID, userBase);
                        }
                        myCommand.Dispose();
                        reader.Close();
                    }
                }
            }
        }
        private void DbInsert_Members()
        {
            txtLogs.Clear();
            if (Connection.IsOpen())
            {
                foreach (var item in users)
                {
                    using (SQLiteCommand myCommand = new SQLiteCommand("Select * from tb_Members where UserID =" + item.Key + "", Connection.baglanti))
                    {
                        using (SQLiteDataReader reader = myCommand.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                using (SQLiteCommand myCommandUpdate = new SQLiteCommand("insert into tb_Members (UserID,Name) values (@UserID,@Name)", Connection.baglanti))
                                {
                                    myCommandUpdate.Parameters.AddWithValue("@UserID", item.Key.ToString());
                                    myCommandUpdate.Parameters.AddWithValue("@Name", item.Value.Name.ToString());
                                    myCommandUpdate.ExecuteNonQuery();
                                    myCommandUpdate.Dispose();
                                }
                            }
                            reader.Close();
                            myCommand.Cancel();
                        }
                    }
                }
                Logs("Veritabanına ekleme işlemi tamamlandı.");
            }
        }
        private void DbDelete_Members()
        {
            txtLogs.Clear();
            if (Connection.IsOpen())
            {
                using (SQLiteCommand myCommand = new SQLiteCommand("Delete from tb_Members", Connection.baglanti))
                {
                    myCommand.ExecuteReader();
                    myCommand.Cancel();
                }
            }
        }

        private void DbLoad_Setting()
        {
            if (Connection.IsOpen())
            {
                using (SQLiteCommand myCommand = new SQLiteCommand("Select * from Settings where id=1", Connection.baglanti))
                {
                    using (SQLiteDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtApiID.Text = reader["API_ID"].ToString();
                            txtAPiHash.Text = reader["API_HASH"].ToString();
                            txtPhoneNum.Text = reader["PHONE_NUM"].ToString();
                        }
                        myCommand.Dispose();
                        reader.Close();
                    }
                }
            }
        }
        //SQL İşlemleri

        //Channel Or Group Member List
        private async Task btn_listmembers_ClickAsync()
        {
            txtLogs.Clear();
            if (txtGetGroupID.Text == null || txtGetGroupID.Text == "")
            {
                MessageBox.Show("Grup ID girilmedi");
                return;
            }
            try
            {
                int _GroupID = Convert.ToInt32(txtGetGroupID.Text);
                var chats = await client.Messages_GetAllChats(null);
                var channel = (Channel)chats.chats[_GroupID]; // the channel we want
                var participants = await client.Channels_GetAllParticipants(channel);

                foreach (var chat in participants.users)
                {
                    if (chat.Value.ToString() == null ||
                           chat.Value.ToString() == "" ||
                           chat.Value.ToString().Contains("?"))
                        continue;

                    var exists = users.ContainsKey(chat.Key);
                    if (!exists)
                    {
                        UserBase userBase = new UserBase
                        {
                            ID = chat.Value.ID.ToString(),
                            Name = chat.Value.ToString()
                        };
                        users.Add(chat.Key, userBase);

                        Logs("UYE ADI : " + chat.Value.ToString());
                    }
                }
            }catch(Exception ex)
            {
                Logs(ex.Message.ToString());
            }
        }
        //Channel Or Group Üye Listesi


        //Gruba Uye Ekle
        //private const long DurovID = 1668021389;
        private async Task GET_Messages_GetAllChats()
        {
            allchats = await client.Messages_GetAllChats(null);
          
            if (allchats != null)
                SystemIsRun = true;
            else
                SystemIsRun = false;
        }
        private async Task AddMembersGroup()
        {

        //if (allchats == null)
        //{
        //    //Logs("allchats is null");
        //    await GET_Messages_GetAllChats();
        //    Logs("allchats is null Şimdi tekrar tıklayın.");
        //}

            RETURNBACK:
            if (!SystemIsRun)
            {
                Logs("Lütfen Bekleyin.");
                var data = GET_Messages_GetAllChats();//Task.Run(() => Task.FromResult(()));
                data.Wait();
                goto RETURNBACK;
            }
            else
            {
                client.CollectAccessHash = true;
                txtLogs.Clear();

                foreach (var item in users)
                {
                    if (!ThreadRun) return;

                    try
                    {
                        if (item.Value.Name == null ||
                            item.Value.Name == "" ||
                            item.Value.Name.Contains("?")) 
                            continue;

                        InputUser inputUser = new InputUser();
                        var found = await client.Contacts_Search(item.Value.Name, 1);
                        var u = found.users.Values.OfType<User>().FirstOrDefault();
                        if (u != null && u.bot_info_version == 0)
                        {
                            if (u != null)
                            {
                                inputUser.user_id = u.ID;
                                inputUser.access_hash = u.access_hash;
                                await client.Channels_InviteToChannel((Channel)allchats.chats[Convert.ToInt32(txtYourGroupID.Text)], new[] { inputUser });
                                Thread.Sleep(GetRandom());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logs("AddMembersGroup => " + ex.Message.ToString());
                        continue;
                    }
                }

                Logs("Üye eklenme işlemi tamamlandı.");
            }
        }
        //Gruba Uye Ekle

        //Send Message
        private void RunSendMessage()
        {
            Task.Run(async () => await SendMessage()).ConfigureAwait(false);
        }
        private async Task SendMessage()
        {
            Logs("Ileti Gönderilmeye başlandı.");
            foreach (var item in users)
            {

                if (!ThreadRun) return;


                try
                {
                    var found = await client.Contacts_Search(item.Value.Name, 1);
                    var u = found.users.Values.OfType<User>().FirstOrDefault();
                    if (u != null && u.bot_info_version == 0)
                    {
                        if (u != null)
                        {
                            var Result = await client.SendMessageAsync(new InputPeerUser() { user_id = u.id, access_hash = u.access_hash }, txtMessage.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logs(ex.Message.ToString());
                }
                Thread.Sleep(GetRandom());
                Logs(item.Value.Name + " Kişisine ileti Gönderildi.");
            }
        }
        //Send Message end



        //Buttons
        private void Run_btn_listmembers(object sender, EventArgs e)
        {
            Task.Run(async () => await btn_listmembers_ClickAsync()).ConfigureAwait(false);
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == null || txtMessage.Text == "")
            {
                MessageBox.Show("Mesaj Kısmı girilmedi.");
                return;
            }
            else
            {
                new Thread(new ThreadStart(() => RunSendMessage()))
                {
                    IsBackground = true
                }.Start();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var pAPI_ID = txtApiID.Text;
            var pAPI_HASH = txtAPiHash.Text;
            var pPHONE_NUM = txtPhoneNum.Text;

            using (SQLiteCommand myCommandUpdate = new SQLiteCommand("update Settings set API_ID = @dAPI_ID, API_HASH = @dAPI_HASH, PHONE_NUM = @dPHONE_NUM where id = 1", Connection.baglanti))
            {
                myCommandUpdate.Parameters.AddWithValue("@dAPI_ID", pAPI_ID);
                myCommandUpdate.Parameters.AddWithValue("@dAPI_HASH", pAPI_HASH);
                myCommandUpdate.Parameters.AddWithValue("@dPHONE_NUM", pPHONE_NUM);
                myCommandUpdate.ExecuteNonQuery();
            }
        }
        //Buttons end

        //Menus
        private void grupListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RETURNBACK:
            if (!SystemIsRun)
            {
                Logs("Lütfen Bekleyin.");
                var data = GET_Messages_GetAllChats();//Task.Run(() => Task.FromResult(()));
                data.Wait();
                goto RETURNBACK;
            }
            else
            {
                txtLogs.Clear();
                foreach (var chata in allchats.chats.ToList())
                    if (chata.Value.IsActive)
                        Logs("ChatID:\t" + chata.Value.ID + "\tTITLE:\t" + chata.Value.Title);
            }
        }
        private void grubaUyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(async () => await AddMembersGroup()).ConfigureAwait(false);
        }
        private void databaseUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbInsert_Members();
        }
        private void databaseAllDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDelete_Members();
        }
        private void baslatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadRun = true;
            baslatToolStripMenuItem.Enabled = false;
            durdurToolStripMenuItem.Enabled = true;
            _ = StartingAsync();
        }
        private void durdurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadRun = true;
            baslatToolStripMenuItem.Enabled = true;
            durdurToolStripMenuItem.Enabled = false;
        }
        //Menus end
    }
}