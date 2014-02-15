using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Data.Fields;

namespace SitecoreBasics.Extensions
{
    /// <summary>
    /// This class will be used to
    /// provide extension methods for Item class
    /// </summary>
    public static class ItemClassExtensions
    {
        /// <summary>
        /// This extension method will be used to check whether item
        /// exist in current Sitecore Context language or not
        /// </summary>
        /// <param name="item">Item to check version for</param>
        /// <returns>true if exist else false</returns>
        public static bool IsLanguageVersionExist(this Item item)
        {
            bool isExist = false;
            Sitecore.Data.Items.Item itemInLanguage =
                item.Database.GetItem(item.ID, Sitecore.Context.Language);
            isExist = itemInLanguage.Versions.Count > 0;
            return isExist;
        }

        /// <summary>
        /// This extension method will be used to check whether item
        /// exist in current provided language or not
        /// </summary>
        /// <param name="item">Item to check version for</param>
        /// <param name="languageToCheck">Language version to check for</param>
        /// <returns>true if exist else false</returns>
        public static bool IsLanguageVersionExist(this Item item, Language languageToCheck)
        {
            bool isExist = false;
            Sitecore.Data.Items.Item itemInLanguage =
                item.Database.GetItem(item.ID, languageToCheck);
            isExist = itemInLanguage.Versions.Count > 0;
            return isExist;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get Boolean value from provided field.
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static bool GetBooleanField(this Item item, string fieldName)
        {
            Field fieldValue = item.Fields[fieldName];

            if (fieldValue != null)
                return (fieldValue.Value == "1" ? true : false);
            else
                return false;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get media item value from provided field.
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static MediaItem GetMediaItemField(this Item item, string fieldName)
        {
            Field fieldValue = item.Fields[fieldName];
            MediaItem mediaItem = null;

            if ((fieldValue != null) && (fieldValue.HasValue))
                mediaItem = ((ImageField)fieldValue).MediaItem;

            return mediaItem;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get string value from provided field.
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static String GetStringField(this Item item, String fieldName)
        {
            string fieldValue = string.Empty;
            if (item != null)
            {
                Field field = item.Fields[fieldName];
                if ((field != null) && (!string.IsNullOrEmpty(field.Value)))
                    fieldValue = field.Value;
            }
            return fieldValue;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get date value from provided field.
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static DateTime GetDateField(this Item item, String fieldName)
        {
            DateField fieldValue = item.Fields[fieldName];
            DateTime dateTime = DateTime.Now;
            if ((fieldValue != null) && (fieldValue.InnerField.Value != null))
                dateTime = fieldValue.DateTime;

            return dateTime;
        }
        
        /// <summary>
        /// This extension method will be used to 
        /// get HtmlField value from provided field.
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static HtmlField GetHtmlField(this Item item, String fieldName)
        {
            HtmlField htmlField = item.Fields[fieldName];
            return htmlField;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get LinkField value from provided field.
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static LinkField GetLinkField(this Item item, String fieldName)
        {   
            LinkField linkField = item.Fields[fieldName];
            return linkField;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get ReferenceField value from provided field.
        /// Useful for : Droplink, Droptree, Grouped Droplink
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static ReferenceField GetReferenceField(this Item item, String fieldName)
        {            
            ReferenceField referenceField = item.Fields[fieldName];
            return referenceField;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get ReferenceField Item's reference from provided field.
        /// Useful for : Droplink, Droptree, Grouped Droplink
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static Item GetReferenceFieldItem(this Item item, String fieldName)
        {
            Item targetItem = null;
            ReferenceField referenceField = item.Fields[fieldName];
            if ((referenceField != null) && (referenceField.TargetItem != null))
                targetItem = referenceField.TargetItem;

            return targetItem;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get MultilistField from provided field.
        /// Useful for : Checklist, Multilist, Treelist, Treelist-Ex
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static MultilistField GetMultilistField(this Item item, String fieldName)
        {
            MultilistField multilistField = item.Fields[fieldName];
            return multilistField;
        }

        /// <summary>
        /// This extension method will be used to 
        /// get MultilistField items from provided field.
        /// Useful for : Checklist, Multilist, Treelist, Treelist-Ex
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>value of the field</returns>
        public static Item[] GetMultilistFieldItems(this Item item, String fieldName)
        {            
            Item[] targetItems = null;
            MultilistField multilistField = item.Fields[fieldName];
            if ((multilistField != null) && (multilistField.InnerField != null))
                targetItems = multilistField.GetItems();

            return targetItems;
        }
        

    }
}
