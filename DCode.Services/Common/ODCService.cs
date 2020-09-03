﻿using DCode.Common;
using DCode.Models.ODC;
using System;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace DCode.Services.Common
{
    public class ODCService : IODCService
    {
        /// <summary>
        /// Returns the ODCs present in the system 
        /// This reads the details from the Master ODC list, serializes and returns the list
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        public ExistingODCList GetExistingODCList(string xmlFilePath)
        {
            ExistingODCList result;
            var xmlInputData = File.ReadAllText(xmlFilePath);
            XmlSerializer serializer = new XmlSerializer(typeof(ExistingODCList));
            using (StringReader reader = new StringReader(xmlInputData))
            {
                result = (ExistingODCList)(serializer.Deserialize(reader));
            }

            return result;
        }

        /// <summary>
        /// Get the ODC details by the offering ID
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="offeringId"></param>
        /// <returns></returns>
        public ODC GetExistingODCByOfferingId(string xmlFilePath, string offeringId)
        {
            var odcList = GetExistingODCList(xmlFilePath);
            return odcList.ODCList.Where(off => off.OfferingId == offeringId).FirstOrDefault();
        }

        /// <summary>
        /// This method is responsible to indentify if the user is part of any specific ODC's distribution list.
        /// If yes he will have access to additional feature specific to that ODC
        /// </summary>
        /// <returns></returns>
        public void SetODCAccess(Models.User.UserContext _userContext)
        {
            _userContext.AccessibleODCId = 0;
            var odcList = GetExistingODCList(AppDomain.CurrentDomain.BaseDirectory + Constants.ODCPath);
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, Constants.UserDomain);

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, _userContext.EmailId);

            foreach (var odc in odcList.ODCList)
            {
                foreach (var groupName in odc.DistributionList.Split(new char[] { ',' }))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, groupName);
                    if (user != null && group != null)
                    {
                        // check if user is member of that group
                        if (user.IsMemberOf(group))
                        {
                            _userContext.AccessibleODCId = Convert.ToInt32(odc.OfferingId);
                            _userContext.HasODCAccess = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}