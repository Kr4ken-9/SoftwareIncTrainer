﻿using UnityEngine;
using System.Collections.Generic;

namespace Trainer
{
    //Your mod should have exactly one class that implements the ModMeta interface
    public class Main : ModMeta
    {
        //This function is used to generate the content in the "Mods" section of the options window
        //The behaviors array contains all behaviours that have been spawned for this mod, one for each implementation
        
        #region Fields

        public static bool opened = false;
        public static GUIWindow win;

        static string version = "(v2.12)";

        #endregion

        public static void Button()
        {
            var btn = WindowManager.SpawnButton();
            btn.GetComponentInChildren<UnityEngine.UI.Text>().text = "Trainer " + version;
            btn.onClick.AddListener(Window);
            WindowManager.AddElementToElement(btn.gameObject, WindowManager.FindElementPath("MainPanel/Holder/FanPanel", null).gameObject, new Rect(164, 0, 100, 32), new Rect(0, 0, 0, 0));
        }
        
        public static void Window()
        {
            if (!opened)
            {
                opened = true;

                #region Initialization

                win = WindowManager.SpawnWindow();
                win.InitialTitle = "Trainer Settings, by Trawis " + version;
                win.TitleText.text = "TrainerSettings, by Trawis " + version;
                win.NonLocTitle = "TrainerSettings, by Trawis " + version;
                win.MinSize.x = 670;
                win.MinSize.y = 580;

                List<GameObject> btn = new List<GameObject>();
                List<GameObject> col1 = new List<GameObject>();
                List<GameObject> col2 = new List<GameObject>();
                List<GameObject> col3 = new List<GameObject>();

                #endregion

                #region Money

                //Button for some Money
                var buttonMoney = WindowManager.SpawnButton();
                buttonMoney.GetComponentInChildren<UnityEngine.UI.Text>().text = "Add Money";
                buttonMoney.onClick.AddListener(() => TrainerBehaviour.IncreaseMoney());
                WindowManager.AddElementToWindow(buttonMoney.gameObject, win, new Rect(1, 0, 150, 32), new Rect(0, 0, 0, 0));

                #endregion

                #region Reputation

                //Button for AddRep
                var buttonAddRep = WindowManager.SpawnButton();
                buttonAddRep.GetComponentInChildren<UnityEngine.UI.Text>().text = "Add Reputation";
                buttonAddRep.onClick.AddListener(() => TrainerBehaviour.AddRep());
                WindowManager.AddElementToWindow(buttonAddRep.gameObject, win, new Rect(161, 0, 150, 32), new Rect(0, 0, 0, 0));

                #endregion

                #region Universal Integer Mods

                //Change product price for my company

                var inputProductName = WindowManager.SpawnInputbox();
                inputProductName.text = "Product Name Here";
                inputProductName.onValueChanged.AddListener(boxText => TrainerBehaviour.price_ProductName = boxText);
                WindowManager.AddElementToWindow(inputProductName.gameObject, win, new Rect(1, 96, 150, 32), new Rect(0, 0, 0, 0));

                var buttonSetProductPrice = WindowManager.SpawnButton();
                buttonSetProductPrice.GetComponentInChildren<UnityEngine.UI.Text>().text = "Set Product Price";
                buttonSetProductPrice.onClick.AddListener(() => TrainerBehaviour.SetProductPrice());
                WindowManager.AddElementToWindow(buttonSetProductPrice.gameObject, win, new Rect(161, 96, 150, 32), new Rect(0, 0, 0, 0));

                var buttonSetProductStock = WindowManager.SpawnButton();
                buttonSetProductStock.GetComponentInChildren<UnityEngine.UI.Text>().text = "Set Product Stock";
                buttonSetProductStock.onClick.AddListener(() => TrainerBehaviour.SetProductStock());
                WindowManager.AddElementToWindow(buttonSetProductStock.gameObject, win, new Rect(322, 96, 150, 32), new Rect(0, 0, 0, 0));

                var buttonSetActiveUsers = WindowManager.SpawnButton();
                buttonSetActiveUsers.GetComponentInChildren<UnityEngine.UI.Text>().text = "Set Active Users";
                buttonSetActiveUsers.onClick.AddListener(() => TrainerBehaviour.AddActiveUsers());
                WindowManager.AddElementToWindow(buttonSetActiveUsers.gameObject, win, new Rect(483, 96, 150, 32), new Rect(0, 0, 0, 0));

                #endregion

                #region Maximum

                var buttonMaxFollowers = WindowManager.SpawnButton();
                buttonMaxFollowers.GetComponentInChildren<UnityEngine.UI.Text>().text = "Max Followers";
                buttonMaxFollowers.onClick.AddListener(() => TrainerBehaviour.MaxFollowers());
                WindowManager.AddElementToWindow(buttonMaxFollowers.gameObject, win, new Rect(1, 32, 150, 32), new Rect(0, 0, 0, 0));

                var buttonFixBugs = WindowManager.SpawnButton();
                buttonFixBugs.GetComponentInChildren<UnityEngine.UI.Text>().text = "Fix Bugs";
                buttonFixBugs.onClick.AddListener(() => TrainerBehaviour.FixBugs());
                WindowManager.AddElementToWindow(buttonFixBugs.gameObject, win, new Rect(161, 32, 150, 32), new Rect(0, 0, 0, 0));

                var buttonMaxCode = WindowManager.SpawnButton();
                buttonMaxCode.GetComponentInChildren<UnityEngine.UI.Text>().text = "Max Code";
                buttonMaxCode.onClick.AddListener(() => TrainerBehaviour.MaxCode());
                WindowManager.AddElementToWindow(buttonMaxCode.gameObject, win, new Rect(322, 32, 150, 32), new Rect(0, 0, 0, 0));

                var buttonMaxArt = WindowManager.SpawnButton();
                buttonMaxArt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Max Art";
                buttonMaxArt.onClick.AddListener(() => TrainerBehaviour.MaxArt());
                WindowManager.AddElementToWindow(buttonMaxArt.gameObject, win, new Rect(483, 32, 150, 32), new Rect(0, 0, 0, 0));

                #endregion

                #region Companies

                //Takeover Company

                var buttonTakeoverCompany = WindowManager.SpawnButton();
                buttonTakeoverCompany.GetComponentInChildren<UnityEngine.UI.Text>().text = "Takeover Company";
                buttonTakeoverCompany.onClick.AddListener(() => TrainerBehaviour.TakeoverCompany());
                WindowManager.AddElementToWindow(buttonTakeoverCompany.gameObject, win, new Rect(1, 160, 150, 32), new Rect(0, 0, 0, 0));

                var buttonSubsidiaryCompany = WindowManager.SpawnButton();
                buttonSubsidiaryCompany.GetComponentInChildren<UnityEngine.UI.Text>().text = "Subsidiary Company";
                buttonSubsidiaryCompany.onClick.AddListener(() => TrainerBehaviour.SubDCompany());
                WindowManager.AddElementToWindow(buttonSubsidiaryCompany.gameObject, win, new Rect(161, 160, 150, 32), new Rect(0, 0, 0, 0));

                var buttonForceBankrupt = WindowManager.SpawnButton();
                buttonForceBankrupt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Bankrupt";
                buttonForceBankrupt.onClick.AddListener(() => TrainerBehaviour.ForceBankrupt());
                WindowManager.AddElementToWindow(buttonForceBankrupt.gameObject, win, new Rect(322, 160, 150, 32), new Rect(0, 0, 0, 0));

                #endregion

                #region AI Bankrupt
                var buttonAIBankrupt = WindowManager.SpawnButton();
                buttonAIBankrupt.GetComponentInChildren<UnityEngine.UI.Text>().text = "AI Bankrupt All";
                buttonAIBankrupt.onClick.AddListener(() => TrainerBehaviour.AIBankrupt());
                btn.Add(buttonAIBankrupt.gameObject);

                #endregion

                #region MonthDays

                //Button for Changing days per month
                var buttonMonthDays = WindowManager.SpawnButton();
                buttonMonthDays.GetComponentInChildren<UnityEngine.UI.Text>().text = "Days per month";
                buttonMonthDays.onClick.AddListener(() =>
                {
                    TrainerBehaviour.MonthDays();
                });
                btn.Add(buttonMonthDays.gameObject);

                #endregion

                #region Loans

                //Button for Loan Clear
                var buttonClrLoan = WindowManager.SpawnButton();
                buttonClrLoan.GetComponentInChildren<UnityEngine.UI.Text>().text = "Clear all loans";
                buttonClrLoan.onClick.AddListener(() =>
                {
                    TrainerBehaviour.ClearLoans();
                });
                btn.Add(buttonClrLoan.gameObject);

                #endregion

                #region HR

                var buttonHREmployees = WindowManager.SpawnButton();
                buttonHREmployees.GetComponentInChildren<UnityEngine.UI.Text>().text = "HR Leaders";
                buttonHREmployees.onClick.AddListener(() => TrainerBehaviour.HREmployees());
                btn.Add(buttonHREmployees.gameObject);

                #endregion

                #region Max Skill

                //Button for MaxSkill
                var buttonMaxSkill = WindowManager.SpawnButton();
                buttonMaxSkill.GetComponentInChildren<UnityEngine.UI.Text>().text = "Max Skill of employees";
                buttonMaxSkill.onClick.AddListener(() =>
                {
                    TrainerBehaviour.EmployeesToMax();
                });
                btn.Add(buttonMaxSkill.gameObject);

                #endregion

                #region Remove Products

                var buttonRemoveProducts = WindowManager.SpawnButton();
                buttonRemoveProducts.GetComponentInChildren<UnityEngine.UI.Text>().text = "Remove products";
                buttonRemoveProducts.onClick.AddListener(() => TrainerBehaviour.RemoveSoft());
                btn.Add(buttonRemoveProducts.gameObject);

                #endregion

                #region Employee Age

                //Button for EmployeeAge
                var buttonEmployeeAge = WindowManager.SpawnButton();
                buttonEmployeeAge.GetComponentInChildren<UnityEngine.UI.Text>().text = "Reset age of employees";
                buttonEmployeeAge.onClick.AddListener(() =>
                {
                    TrainerBehaviour.ResetAgeOfEmployees();
                });
                btn.Add(buttonEmployeeAge.gameObject);

                #endregion

                #region Sell Products

                var buttonSellProductsStock = WindowManager.SpawnButton();
                buttonSellProductsStock.GetComponentInChildren<UnityEngine.UI.Text>().text = "Sell products stock";
                buttonSellProductsStock.onClick.AddListener(() => TrainerBehaviour.SellProductsStock());
                btn.Add(buttonSellProductsStock.gameObject);

                #endregion

                #region Unlock All

                //Button for UnlockAll
                var buttonUnlockAll = WindowManager.SpawnButton();
                buttonUnlockAll.GetComponentInChildren<UnityEngine.UI.Text>().text = "Unlock all furniture";
                buttonUnlockAll.onClick.AddListener(() =>
                {
                    TrainerBehaviour.UnlockAll();
                });
                btn.Add(buttonUnlockAll.gameObject);

                #endregion

                #region Max Land

                //Button for MaxLand
                var buttonMaxLand = WindowManager.SpawnButton();
                buttonMaxLand.GetComponentInChildren<UnityEngine.UI.Text>().text = "Unlock all space";
                buttonMaxLand.onClick.AddListener(() =>
                {
                    TrainerBehaviour.UnlockAllSpace();
                });
                btn.Add(buttonMaxLand.gameObject);

                #endregion

                #region Employee Management

                //Employees Management
                //CheckBox for Disable Needs
                var lockNeeds = WindowManager.SpawnCheckbox();
                lockNeeds.GetComponentInChildren<UnityEngine.UI.Text>().text = "Disable Needs";
                lockNeeds.isOn = TrainerBehaviour.LockNeeds;
                lockNeeds.onValueChanged.AddListener(a => TrainerBehaviour.LockNeeds = !TrainerBehaviour.LockNeeds);
                col1.Add(lockNeeds.gameObject);

                //CheckBox for LockEmployeeStress
                var lockStress = WindowManager.SpawnCheckbox();
                lockStress.GetComponentInChildren<UnityEngine.UI.Text>().text = "Disable Stress";
                lockStress.isOn = TrainerBehaviour.LockStress;
                lockStress.onValueChanged.AddListener(a => TrainerBehaviour.LockStress = !TrainerBehaviour.LockStress);
                col1.Add(lockStress.gameObject);

                //CheckBox for Free Employees
                var lockEmpSal = WindowManager.SpawnCheckbox();
                lockEmpSal.GetComponentInChildren<UnityEngine.UI.Text>().text = "Free Employees";
                lockEmpSal.isOn = TrainerBehaviour.FreeEmployees;
                lockEmpSal.onValueChanged.AddListener(a => TrainerBehaviour.FreeEmployees = !TrainerBehaviour.FreeEmployees);
                col1.Add(lockEmpSal.gameObject);

                //CheckBox for Free Staff
                var toggleFreeStaff = WindowManager.SpawnCheckbox();
                toggleFreeStaff.GetComponentInChildren<UnityEngine.UI.Text>().text = "Free Staff";
                toggleFreeStaff.isOn = TrainerBehaviour.FreeStaff;
                toggleFreeStaff.onValueChanged.AddListener(a => TrainerBehaviour.FreeStaff = !TrainerBehaviour.FreeStaff);
                col1.Add(toggleFreeStaff.gameObject);

                //CheckBox for Efficiency
                var lockEffSat = WindowManager.SpawnCheckbox();
                lockEffSat.GetComponentInChildren<UnityEngine.UI.Text>().text = "Full Efficiency";
                lockEffSat.isOn = TrainerBehaviour.LockEffSat;
                lockEffSat.onValueChanged.AddListener(a => TrainerBehaviour.LockEffSat = !TrainerBehaviour.LockEffSat);
                col1.Add(lockEffSat.gameObject);

                //CheckBox for Satisfaction
                var lockSat = WindowManager.SpawnCheckbox();
                lockSat.GetComponentInChildren<UnityEngine.UI.Text>().text = "Full Satisfaction";
                lockSat.isOn = TrainerBehaviour.LockSat;
                lockSat.onValueChanged.AddListener(a => TrainerBehaviour.LockSat = !TrainerBehaviour.LockSat);
                col1.Add(lockSat.gameObject);

                //CheckBox for EmployeeAge
                var lockAge = WindowManager.SpawnCheckbox();
                lockAge.GetComponentInChildren<UnityEngine.UI.Text>().text = "Lock age of employees";
                lockAge.isOn = TrainerBehaviour.LockAge;
                lockAge.onValueChanged.AddListener(a => TrainerBehaviour.LockAge = !TrainerBehaviour.LockAge);
                col1.Add(lockAge.gameObject);

                //CheckBox for No Vacation
                var toggleNoVacation = WindowManager.SpawnCheckbox();
                toggleNoVacation.GetComponentInChildren<UnityEngine.UI.Text>().text = "No Vacation";
                toggleNoVacation.isOn = TrainerBehaviour.NoVacation;
                toggleNoVacation.onValueChanged.AddListener(a => TrainerBehaviour.NoVacation = !TrainerBehaviour.NoVacation);
                col1.Add(toggleNoVacation.gameObject);

                var toggleNoSickness = WindowManager.SpawnCheckbox();
                toggleNoSickness.GetComponentInChildren<UnityEngine.UI.Text>().text = "No Sickness";
                toggleNoSickness.isOn = TrainerBehaviour.NoSickness;
                toggleNoSickness.onValueChanged.AddListener(a => TrainerBehaviour.NoSickness = !TrainerBehaviour.NoSickness);
                col1.Add(toggleNoSickness.gameObject);

                //CheckBox for Efficiency & Satisfaction
                var toggMaxOutEff = WindowManager.SpawnCheckbox();
                toggMaxOutEff.GetComponentInChildren<UnityEngine.UI.Text>().text = "Ultra Efficiency (Tick Full Eff first)";
                toggMaxOutEff.isOn = TrainerBehaviour.MaxOutEff;
                toggMaxOutEff.onValueChanged.AddListener(a => TrainerBehaviour.MaxOutEff = !TrainerBehaviour.MaxOutEff);
                col1.Add(toggMaxOutEff.gameObject);
                //Employees Management END

                #endregion

                #region Room Management

                //Room Management
                //CheckBox for Full Environment
                var toggleFullEnv = WindowManager.SpawnCheckbox();
                toggleFullEnv.GetComponentInChildren<UnityEngine.UI.Text>().text = "Full Environment";
                toggleFullEnv.isOn = TrainerBehaviour.FullEnv;
                toggleFullEnv.onValueChanged.AddListener(a => TrainerBehaviour.FullEnv = !TrainerBehaviour.FullEnv);
                col2.Add(toggleFullEnv.gameObject);

                //CheckBox for Fullbright
                var toggleFullbright = WindowManager.SpawnCheckbox();
                toggleFullbright.GetComponentInChildren<UnityEngine.UI.Text>().text = "Full Sun light";
                toggleFullbright.isOn = TrainerBehaviour.Fullbright;
                toggleFullbright.onValueChanged.AddListener(a => TrainerBehaviour.Fullbright = !TrainerBehaviour.Fullbright);
                col2.Add(toggleFullbright.gameObject);

                //CheckBox for Lock temperature to 21 degree
                var toggleTempLock = WindowManager.SpawnCheckbox();
                toggleTempLock.GetComponentInChildren<UnityEngine.UI.Text>().text = "Lock temperature to 21";
                toggleTempLock.isOn = TrainerBehaviour.TempLock;
                toggleTempLock.onValueChanged.AddListener(a => TrainerBehaviour.TempLock = !TrainerBehaviour.TempLock);
                col2.Add(toggleTempLock.gameObject);

                var toggleNoMaintenance = WindowManager.SpawnCheckbox();
                toggleNoMaintenance.GetComponentInChildren<UnityEngine.UI.Text>().text = "No Maintenance";
                toggleNoMaintenance.isOn = TrainerBehaviour.NoMaintenance;
                toggleNoMaintenance.onValueChanged.AddListener(a => TrainerBehaviour.NoMaintenance = !TrainerBehaviour.NoMaintenance);
                col2.Add(toggleNoMaintenance.gameObject);

                //CheckBox for Noise Reduction
                var toggleNoiseRed = WindowManager.SpawnCheckbox();
                toggleNoiseRed.GetComponentInChildren<UnityEngine.UI.Text>().text = "Noise Reduction";
                toggleNoiseRed.isOn = TrainerBehaviour.NoiseRed;
                toggleNoiseRed.onValueChanged.AddListener(a => TrainerBehaviour.NoiseRed = !TrainerBehaviour.NoiseRed);
                col2.Add(toggleNoiseRed.gameObject);

                //CheckBox for CleanRooms
                var toggleCleanRooms = WindowManager.SpawnCheckbox();
                toggleCleanRooms.GetComponentInChildren<UnityEngine.UI.Text>().text = "Rooms are always clean";
                toggleCleanRooms.isOn = TrainerBehaviour.CleanRooms;
                toggleCleanRooms.onValueChanged.AddListener(a => TrainerBehaviour.CleanRooms = !TrainerBehaviour.NoiseRed);
                col2.Add(toggleCleanRooms.gameObject);
                //Room Management END

                #endregion

                #region Company Management

                //Company Management
                var toggleAutoDistDeal = WindowManager.SpawnCheckbox();
                toggleAutoDistDeal.GetComponentInChildren<UnityEngine.UI.Text>().text = "Auto Distribution Deals";
                toggleAutoDistDeal.isOn = TrainerBehaviour.dDeal;
                toggleAutoDistDeal.onValueChanged.AddListener(a => TrainerBehaviour.dDeal = !TrainerBehaviour.dDeal);
                col3.Add(toggleAutoDistDeal.gameObject);

                var toggleFreePrint = WindowManager.SpawnCheckbox();
                toggleFreePrint.GetComponentInChildren<UnityEngine.UI.Text>().text = "Free Print";
                toggleFreePrint.isOn = TrainerBehaviour.FreePrint;
                toggleFreePrint.onValueChanged.AddListener(a => TrainerBehaviour.FreePrint = !TrainerBehaviour.FreePrint);
                col3.Add(toggleFreePrint.gameObject);

                //CheckBox for Free Water & Electricity
                var toggleNoWaterElect = WindowManager.SpawnCheckbox();
                toggleNoWaterElect.GetComponentInChildren<UnityEngine.UI.Text>().text = "Free Water & Electricity";
                toggleNoWaterElect.isOn = TrainerBehaviour.NoWaterElect;
                toggleNoWaterElect.onValueChanged.AddListener(a => TrainerBehaviour.NoWaterElect = !TrainerBehaviour.NoWaterElect);
                col3.Add(toggleNoWaterElect.gameObject);

                var toggleBookshelfSkill = WindowManager.SpawnCheckbox();
                toggleBookshelfSkill.GetComponentInChildren<UnityEngine.UI.Text>().text = "Increase Bookshelf Skill";
                toggleBookshelfSkill.isOn = TrainerBehaviour.IncBookshelfSkill;
                toggleBookshelfSkill.onValueChanged.AddListener(a => TrainerBehaviour.IncBookshelfSkill = !TrainerBehaviour.IncBookshelfSkill);
                col3.Add(toggleBookshelfSkill.gameObject);

                var toggleIncCourierCap = WindowManager.SpawnCheckbox();
                toggleIncCourierCap.GetComponentInChildren<UnityEngine.UI.Text>().text = "Increase Courier Capacity";
                toggleIncCourierCap.isOn = TrainerBehaviour.IncCourierCap;
                toggleIncCourierCap.onValueChanged.AddListener(a => TrainerBehaviour.IncCourierCap = !TrainerBehaviour.IncCourierCap);
                col3.Add(toggleIncCourierCap.gameObject);

                var togglePrintSpeed = WindowManager.SpawnCheckbox();
                togglePrintSpeed.GetComponentInChildren<UnityEngine.UI.Text>().text = "Increase Print Speed";
                togglePrintSpeed.isOn = TrainerBehaviour.IncPrintSpeed;
                togglePrintSpeed.onValueChanged.AddListener(a => TrainerBehaviour.IncPrintSpeed = !TrainerBehaviour.IncPrintSpeed);
                col3.Add(togglePrintSpeed.gameObject);

                var toggleMoreHosting = WindowManager.SpawnCheckbox();
                toggleMoreHosting.GetComponentInChildren<UnityEngine.UI.Text>().text = "More Hosting Deals";
                toggleMoreHosting.isOn = TrainerBehaviour.MoreHosting;
                toggleMoreHosting.onValueChanged.AddListener(a => TrainerBehaviour.MoreHosting = !TrainerBehaviour.MoreHosting);
                col3.Add(toggleMoreHosting.gameObject);

                var toggleRedISPCost = WindowManager.SpawnCheckbox();
                toggleRedISPCost.GetComponentInChildren<UnityEngine.UI.Text>().text = "Reduce Internet Cost";
                toggleRedISPCost.isOn = TrainerBehaviour.RedISPCost;
                toggleRedISPCost.onValueChanged.AddListener(a => TrainerBehaviour.RedISPCost = !TrainerBehaviour.RedISPCost);
                col3.Add(toggleRedISPCost.gameObject);

                //Company Management END

                #endregion

                #region Loops

                for (var i = 0; i < btn.Count; i++)
                {
                    var item = btn[i];

                    WindowManager.AddElementToWindow(item, win, new Rect(1, (i + 7) * 32, 150, 32),
                        new Rect(0, 0, 0, 0));
                }

                for (int i = 0; i < col1.Count; i++)
                {
                    var item = col1[i];

                    WindowManager.AddElementToWindow(item, win, new Rect(161, (i + 7) * 32, 150, 32),
                        new Rect(0, 0, 0, 0));
                }

                for (int i = 0; i < col2.Count; i++)
                {
                    var item = col2[i];

                    WindowManager.AddElementToWindow(item, win, new Rect(322, (i + 7) * 32, 150, 32),
                        new Rect(0, 0, 0, 0));
                }

                for (int i = 0; i < col3.Count; i++)
                {
                    var item = col3[i];

                    WindowManager.AddElementToWindow(item, win, new Rect(483, (i + 7) * 32, 150, 32),
                        new Rect(0, 0, 0, 0));
                }

                #endregion
            }
            else
            {
                win.Close();
                opened = false;
            }
        }
        
        public void ConstructOptionsScreen(RectTransform parent, ModBehaviour[] behaviours)
        {
            var label = WindowManager.SpawnLabel();
            label.text = "Created by LtPain, edit by Trawis\n\nOptions have been moved to the Main Screen of the game.\nPlease load a game and press 'Trainer' button.";
            WindowManager.AddElementToElement(label.gameObject, parent.gameObject, new Rect(0, 0, 400, 128),
                new Rect(0, 0, 0, 0));
        }

        public string Name => "Trainer v2";
    }
}