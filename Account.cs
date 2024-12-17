using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3C8
{
    /// <summary>
    /// Représente un compte bancaire avec un solde et des informations de titulaire.
    /// </summary>
    internal class Account
    {
        public int sold { get; protected set; }

        public string name { get; set;}
        public string sexe { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Account"/>.
        /// </summary>
        /// <param name="pName">Nom du titulaire du compte.</param>
        /// <param name="pSold">Solde initial du compte.</param>
        /// <param name="pSexe">Sexe du titulaire (true = Male, false = Female).</param>
        public Account(string pName,int pSold,bool pSexe) 
        {
            name = pName;
            sold = pSold;
            sexe = pSexe ? "Male" : "Female";
        }


        /// <summary>
        /// Ajoute un montant au solde du compte.
        /// </summary>
        /// <param name="montant">Montant à ajouter au compte.</param>
        /// <returns>
        /// Retourne <c>true</c> si le montant a été ajouté avec succès, sinon <c>false</c>.
        /// </returns>
        public bool AddFunds(int amount)
        {
            if (amount > 0)
            {
                sold += amount;
                return true; // success
            }
            return false; // fail
        }

        /// <summary>
        /// Retire un montant du solde du compte si les fonds sont suffisants.
        /// </summary>
        /// <param name="montant">Montant à retirer du compte.</param>
        /// <returns>
        /// Retourne <c>true</c> si le retrait a réussi, sinon <c>false</c>.
        /// </returns>
        public bool WithdrawFunds(int amount)
        {
            if (amount > 0 && amount <= sold)
            {
                sold -= amount;
                return true; //  success
            }
            return false; // fail
        }
    }
}
