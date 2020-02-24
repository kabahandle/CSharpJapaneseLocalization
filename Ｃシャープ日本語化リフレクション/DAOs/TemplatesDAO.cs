using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MyDummySQL.DAOs
{
    class TemplatesDAO : MyDAOBase
    {
        public TemplatesDAO(DAOContext con)
            : base(con)
        {
        }

        public DataTable selectAllCategories()
        {
            string sql = @"select distinct categorytext
                            from templates
                            order by categorytext asc
                            ";

            this.ClearParameters();
            //this.AddParameter("pkey", DbType.String, strgKey);

            return base.GetTable(sql);

        }
        /*
        public DataTable selectAllCategories()
        {
            string sql = @"select categorytext
                            from categories
                            order by categorytext asc
                            ";

            this.ClearParameters();
            //this.AddParameter("pkey", DbType.String, strgKey);

            return base.GetTable(sql);

        }*/
        public DataTable selectAllTags()
        {
            string sql = @"select tag
                            from tags
                            order by repeated desc, id desc
                            ";

            this.ClearParameters();
            //this.AddParameter("pkey", DbType.String, strgKey);

            return base.GetTable(sql);

        }
        public bool isExistsTag(string tag)
        {
            string sql = @"select tag
                            from tags
                            where
                                tag like @ptag
                            ";

            this.ClearParameters();
            this.AddParameter("ptag", DbType.String, tag);

            return (base.GetTable(sql).Rows.Count > 0);

        }
        /*
        public bool isExistsCategory(string category)
        {
            string sql = @"select categorytext
                            from categories
                            where
                                categorytext like @pcategory
                            ";

            this.ClearParameters();
            this.AddParameter("pcategory", DbType.String, category);

            return (base.GetTable(sql).Rows.Count > 0);

        }*/
        public DataTable selectAllTextsInCategory(string category)
        {
            string sql = @"select categorytext, templatename. textvalue, tag, repeated
                            from templates
                            where
                                categorytext like @pcategory
                            order by repeated desc, textvalue asc
                            ";

            this.ClearParameters();
            this.AddParameter("pcategory", DbType.String, category);

            return base.GetTable(sql);

        }
        public DataTable selectAllTextsTop00(int num)
        {
            string sql = @"select Top " + num.ToString() + @" categorytext, templatename, textvalue, tag, repeated
                            from templates
                            order by repeated desc, textvalue asc
                            ";

            this.ClearParameters();
            //this.AddParameter("pcategory", DbType.String, category);

            return base.GetTable(sql);

        }
        public DataTable selectAllTexts()
        {
            string sql = @"select id, categorytext, templatename, textvalue, tag, repeated
                            from templates
                            order by repeated desc, textvalue asc
                            ";

            this.ClearParameters();
            //this.AddParameter("pcategory", DbType.String, category);

            return base.GetTable(sql);

        }
        public bool isExistsCategoryAndText(string category, string templatename, string textvalue)
        {
            string sql = @"select *
                            from templates
                            where
                                categorytext like @pcategory
                            and templatename like @ptemplatename
                            and textvalue like @ptextvalue
                            ";

            this.ClearParameters();
            this.AddParameter("pcategory", DbType.String, category);
            this.AddParameter("ptemplatename", DbType.String, templatename);
            this.AddParameter("ptextvalue", DbType.String, textvalue);

            return ( base.GetTable(sql).Rows.Count > 0 );

        }


        public int updateTemplate(string category, string templatename, string textvalue, string tag)
        {
            string sql = @"update templates
                            set
                                repeated = repeated + 1,
                                tag = @ptag
                            where
                                categorytext like @pcategory
                            and templatename like @ptemplatename                           
                            and textvalue like @ptextvalue
                            ";

            this.ClearParameters();
            this.AddParameter("ptag", DbType.String, tag);
            this.AddParameter("pcategorytext", DbType.String, category);
            this.AddParameter("ptextvalue", DbType.String, textvalue);

            return base.ExecuteNonQuery(sql);
        }
        public int updateTemplate(long ID, string category, string templatename, string textvalue, string tag, int repeated)
        {
            string sql = @"update templates
                            set
                                categorytext = @pcategorytext,
                                templatename = @ptemplatename,
                                textvalue = @ptextvalue,
                                repeated = @prepeated,
                                tag = @ptag
                            where
                                id = @pid
                            ";

            this.ClearParameters();
            this.AddParameter("pcategorytext", DbType.String, category);
            this.AddParameter("ptemplatename", DbType.String, templatename);
            this.AddParameter("ptextvalue", DbType.String, textvalue);
            this.AddParameter("prepeated", DbType.Int32, repeated);
            this.AddParameter("ptag", DbType.String, tag);
            this.AddParameter("pid", DbType.Int64, ID);

            return base.ExecuteNonQuery(sql);
        }
        /*
        public int updateCategory(string category)
        {
            string sql = @"update categories
                            set
                                repeated = repeated + 1
                            where
                                categorytext = @pcategory
                            ";

            this.ClearParameters();
            this.AddParameter("pcategory", DbType.String, category);

            return base.ExecuteNonQuery(sql);
        }*/
        public int updateTag(string tag)
        {
            string sql = @"update tags
                            set
                                repeated = repeated + 1
                            where
                                tag = @ptag
                            ";

            this.ClearParameters();
            this.AddParameter("ptag", DbType.String, tag);

            return base.ExecuteNonQuery(sql);
        }
        public int deleteRow(long ID)
        {
            string sql = @"delete from templates
                            where
                                id = @pid
                            ";

            this.ClearParameters();
            this.AddParameter("pid", DbType.Int64, ID);

            return base.ExecuteNonQuery(sql);
        }

        public int incrementRepeated(string category, string templatename, string textvalue)
        {
            string sql = @"update templates
                            set
                                repeated = repeated + 1
                            where
                                categorytext = @pcategory
                            and templatenam = @ptemplatename
                            and textvalue = @ptextvalue
";

            this.ClearParameters();
            this.AddParameter("pcategorytext", DbType.String, category);
            this.AddParameter("ptemplatename", DbType.String, templatename);
            this.AddParameter("ptextvalue", DbType.String, textvalue);

            return base.ExecuteNonQuery(sql);
        }
        public int incrementRepeated(long id)
        {
            string sql = @"update templates
                            set
                                repeated = repeated + 1
                            where
                                id = @pid
";

            this.ClearParameters();
            this.AddParameter("pcategorytext", DbType.Int64, id);

            return base.ExecuteNonQuery(sql);
        }


        public int insertTemplate(string category, string templatename, string textvalue, string tag)
        {
            string sql = @"insert into
                            templates(
                                 categorytext
                                ,templatename
                                ,textvalue
                                ,tag
                                ,repeated
                            )
                            values(
                                 @pcategory
                                ,@ptemplatename
                                ,@ptextvalue
                                ,@ptag
                                ,1
                            )";

            this.ClearParameters();
            this.AddParameter("pcategory", DbType.String, category);
            this.AddParameter("ptemplatename", DbType.String, templatename);
            this.AddParameter("ptextvalue", DbType.String, textvalue);
            this.AddParameter("ptag", DbType.String, tag);

            return base.ExecuteNonQuery(sql);

        }
        public long insertTemplate(string category, string templatename, string textvalue, string tag, int repeated)
        {
            string sql = @"insert into
                            templates(
                                 categorytext
                                ,templatename
                                ,textvalue
                                ,tag
                                ,repeated
                            )
                            values(
                                 @pcategory
                                ,@ptemplatename
                                ,@ptextvalue
                                ,@ptag
                                ,@prepeated
                            )";

            this.ClearParameters();
            this.AddParameter("pcategory", DbType.String, category);
            this.AddParameter("ptemplatename", DbType.String, templatename);
            this.AddParameter("ptextvalue", DbType.String, textvalue);
            this.AddParameter("ptag", DbType.String, tag);
            this.AddParameter("prepeated", DbType.Int32, repeated);

            base.ExecuteNonQuery(sql);
            
            string sql2 = @"select LAST(ID)
                            from templates
                        ";

            this.ClearParameters();

            DataTable tbl =  base.GetTable(sql2);
            long id = 0;
            if (tbl.Rows.Count > 0)
            {
                long.TryParse(tbl.Rows[0][0].ToString(), out id);
            }
            return id;


        }
        public int insertTag(string tag)
        {
            string sql = @"insert into
                            tags(
                                 tag
                                ,repeated
                            )
                            values(
                                @ptag
                                ,1
                            )";

            this.ClearParameters();
            this.AddParameter("ptag", DbType.String, tag);

            return base.ExecuteNonQuery(sql);
        }
        public int insertCategory(string category)
        {
            string sql = @"insert into
                            categories(
                                 categorytext
                                ,repeated
                            )
                            values(
                                @pcategory
                                ,1
                            )";

            this.ClearParameters();
            this.AddParameter("pcategory", DbType.String, category);

            return base.ExecuteNonQuery(sql);
        }

        public int mergeTemplate(string category, string templatename, string textvalue, string tag)
        {
            if (string.IsNullOrEmpty(textvalue))
                return 0;
            if (string.IsNullOrEmpty(category))
                category = "なし";
            if (string.IsNullOrEmpty(tag))
                tag = "なし";

            if (this.isExistsCategoryAndText(category, templatename, textvalue))
            {
                return this.updateTemplate(category, templatename, textvalue, tag);

            }
            else
            {
                return this.insertTemplate(category, templatename, textvalue, tag);
            }
        }

        public int mergeTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                return 0;

            if (this.isExistsTag(tag))
            {
                return this.updateTag(tag);

            }
            else
            {
                return this.insertTag(tag);
            }
        }
        /*
        public int mergeCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                return 0;

            if (this.isExistsCategory(category))
            {
                return this.updateCategory(category);

            }
            else
            {
                return this.insertCategory(category);
            }
        }
        */

    }
}
