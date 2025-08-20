/*
 * ===================================================================================
 * ==                                                                               ==
 * ==    คู่มือการใช้งาน QuickBuy Mod.Call() (API) สำหรับนักพัฒนา                         ==
 * ==    (QuickBuy Mod.Call() (API) Documentation for Developers)                   ==
 * ==                                                                               ==
 * ===================================================================================
 *
 * นี่เป็นคู่มือ สำหรับนักพัฒนาคนอื่นๆ ที่ต้องการเขียนม็อดเพื่อมาเชื่อมต่อกับ QuickBuy
 * คุณสามารถคัดลอก โค้ดตัวอย่างนี้ ไปใช้ในม็อดของคุณได้เลย
 *
 */

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace YourNewModNamespace // เปลี่ยนเป็น Namespace ของม็อดใหม่ที่คุณจะสร้าง
{
    // คลาสนี้เป็นเพียงตัวอย่าง ไม่ต้องนำไปใช้จริง
    public class QuickBuyAPIExamples
    {
        /// <summary>
        /// ฟังก์ชันตัวอย่างหลักในการเรียกใช้ QuickBuy API
        /// </summary>
        public void HowToUseQuickBuyAPI()
        {
            // ขั้นตอนแรกและสำคัญที่สุด: ตรวจสอบเสมอว่าม็อด QuickBuy ถูกเปิดใช้งานอยู่หรือไม่
            if (ModLoader.TryGetMod("QuickBuy", out Mod quickBuyMod))
            {
                // ถ้าหาเจอ เราสามารถเริ่มเรียกใช้คำสั่งต่างๆ ได้จากตรงนี้

                // ดูตัวอย่างการใช้งานแต่ละคำสั่งได้จากฟังก์ชันข้างล่างนี้
                Example_ModifyBalance(quickBuyMod);
                Example_GetBuyPrice(quickBuyMod);
                Example_GetSellPrice(quickBuyMod);
                Example_SpawnItem(quickBuyMod);
            }
            else
            {
                // กรณีที่ผู้เล่นไม่ได้ติดตั้งหรือเปิดใช้งานม็อด QuickBuy
                // ควรเขียนโค้ดรองรับสถานการณ์นี้ด้วย เช่น ปิดการทำงานของฟีเจอร์ที่ต้องใช้ QuickBuy
                Main.NewText("QuickBuy mod is not enabled, features from [Your Mod Name] that rely on it are disabled.", Color.Orange);
            }
        }

        /// <summary>
        /// ตัวอย่างการใช้คำสั่ง "ModifyBalance": ใช้สำหรับเพิ่มหรือลดเงิน QB ของผู้เล่น
        /// </summary>
        /// <param name="quickBuyMod">ตัวแปรอ้างอิงถึงม็อด QuickBuy</param>
        private void Example_ModifyBalance(Mod quickBuyMod)
        {
            /*
             * คำสั่ง: "ModifyBalance"
             * พารามิเตอร์:
             * 1. Player player: ตัวผู้เล่นที่ต้องการจะแก้ไขเงิน
             * 2. long amount: จำนวนเงินที่ต้องการเพิ่ม (เลขบวก) หรือลด (เลขลบ)
             * ค่าที่ส่งกลับ:
             * - bool true เมื่อสำเร็จ
             * - string ข้อความ Error เมื่อล้มเหลว
            */

            // เพิ่มเงิน 1000 QB ให้กับผู้เล่นปัจจุบัน
            quickBuyMod.Call("ModifyBalance", Main.LocalPlayer, 1000L);

            // ลดเงิน 500 QB จากผู้เล่นปัจจุบัน
            quickBuyMod.Call("ModifyBalance", Main.LocalPlayer, -500L);
        }

        /// <summary>
        /// ตัวอย่างการใช้คำสั่ง "GetBuyPrice": ใช้สำหรับดึงราคาซื้อของไอเทม
        /// </summary>
        /// <param name="quickBuyMod">ตัวแปรอ้างอิงถึงม็อด QuickBuy</param>
        private void Example_GetBuyPrice(Mod quickBuyMod)
        {
            /*
             * คำสั่ง: "GetBuyPrice"
             * พารามิเตอร์:
             * 1. int itemID: ID ของไอเทมที่ต้องการทราบราคา (เช่น ItemID.Torch)
             * ค่าที่ส่งกลับ:
             * - long (ราคาซื้อ) เมื่อสำเร็จ
             * - string ข้อความ Error เมื่อล้มเหลว
            */

            object result = quickBuyMod.Call("GetBuyPrice", ItemID.IronBar);
            if (result is long buyPrice)
            {
                Main.NewText($"ราคาซื้อของ Iron Bar คือ: {buyPrice} QB");
            }
            else
            {
                Main.NewText($"ไม่สามารถดึงราคาซื้อได้ Error: {result}");
            }
        }

        /// <summary>
        /// ตัวอย่างการใช้คำสั่ง "GetSellPrice": ใช้สำหรับดึงราคาขายของไอเทม
        /// </summary>
        /// <param name="quickBuyMod">ตัวแปรอ้างอิงถึงม็อด QuickBuy</param>
        private void Example_GetSellPrice(Mod quickBuyMod)
        {
            /*
             * คำสั่ง: "GetSellPrice"
             * พารามิเตอร์:
             * 1. int itemID: ID ของไอเทมที่ต้องการทราบราคา
             * ค่าที่ส่งกลับ:
             * - long (ราคาขาย) เมื่อสำเร็จ
             * - string ข้อความ Error เมื่อล้มเหลว
            */

            object result = quickBuyMod.Call("GetSellPrice", ItemID.GoldBar);
            if (result is long sellPrice)
            {
                Main.NewText($"ราคาขายของ Gold Bar คือ: {sellPrice} QB");
            }
            else
            {
                Main.NewText($"ไม่สามารถดึงราคาขายได้ Error: {result}");
            }
        }

        /// <summary>
        /// ตัวอย่างการใช้คำสั่ง "SpawnItem": ใช้สำหรับส่งของ (สร้าง Delivery Box) ให้กับผู้เล่น
        /// </summary>
        /// <param name="quickBuyMod">ตัวแปรอ้างอิงถึงม็อด QuickBuy</param>
        private void Example_SpawnItem(Mod quickBuyMod)
        {
            /*
             * คำสั่ง: "SpawnItem"
             * พารามิเตอร์:
             * 1. Player player: ตัวผู้เล่นที่จะได้รับของ
             * 2. int itemID: ID ของไอเทมที่จะส่ง
             * 3. int stack: จำนวนของไอเทมที่จะส่ง
             * ค่าที่ส่งกลับ:
             * - bool true เมื่อสำเร็จ
             * - string ข้อความ Error เมื่อล้มเหลว
            */

            // ส่งไม้ (Wood) 99 ชิ้นให้กับผู้เล่นปัจจุบัน
            quickBuyMod.Call("SpawnItem", Main.LocalPlayer, ItemID.Wood, 99);
        }

        /// <summary>
        /// ตัวอย่างการใช้คำสั่ง "GetBalance": ใช้สำหรับดึงยอดเงิน QB คงเหลือของผู้เล่น
        /// </summary>
        private void Example_GetBalance(Mod quickBuyMod)
        {
            /*
             * คำสั่ง: "GetBalance"
             * พารามิเตอร์:
             * 1. Player player: ตัวผู้เล่นที่ต้องการตรวจสอบยอดเงิน
             * ค่าที่ส่งกลับ:
             * - long (ยอดเงินคงเหลือ) เมื่อสำเร็จ
             * - string ข้อความ Error เมื่อล้มเหลว
            */

            object result = quickBuyMod.Call("GetBalance", Main.LocalPlayer);
            if (result is long currentBalance)
            {
                Main.NewText($"Your current QB balance is: {currentBalance:N0} QB");
            }
        }
    }
}