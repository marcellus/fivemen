CREATE OR REPLACE TRIGGER "ASPNET"."TR_DI_STUDENT_APPLY_INFO_I" after delete on TABLE_STUDENT_APPLY_INFO_I
for each row
begin
  delete from table_student_apply_info_c where id=:OLD.id and i_checked!=1;
end;

/
ALTER TRIGGER "ASPNET"."TR_DI_STUDENT_APPLY_INFO_I" ENABLE;



CREATE OR REPLACE TRIGGER "ASPNET"."TR_UI_STUDENT_APPLY_INFO_I" 
  before update on table_student_apply_info_i  
  for each row

begin
   update table_student_apply_info_c set
   
   SFZMHM    =:NEW.SFZMHM ,
  SFZMMC    =:NEW.SFZMMC ,
  I_HMCD    =:NEW.I_HMCD ,
  I_XB             =:NEW.I_XB ,
  C_CSRQ          =:NEW.C_CSRQ ,
  C_GJ             =:NEW.C_GJ ,
  C_DJZSXZQH       =:NEW.C_DJZSXZQH ,
  C_DJZSXXDZ       =:NEW.C_DJZSXXDZ ,
  C_LXZSXZQH      =:NEW.C_LXZSXZQH ,
  C_LXZSXXDZ       =:NEW.C_LXZSXXDZ ,
  C_LXZSYZBM       =:NEW.C_LXZSYZBM ,
  C_LY            =:NEW.C_LY ,
  C_XZQH           =:NEW.C_XZQH ,
  C_LXDH          =:NEW.C_LXDH ,
  C_ZZZM =:NEW.C_ZZZM ,
  C_ZKZMBH         =:NEW.C_ZKZMBH ,
  C_DABH          =:NEW.C_DABH ,
  C_ZKCX           =:NEW.C_ZKCX ,
  C_JXMC          =:NEW.C_JXMC ,
  C_DZYX           =:NEW.C_DZYX ,
  C_SJHM           =:NEW.C_SJHM ,
  C_SG =:NEW.C_SG ,
  I_ZSL            =:NEW.I_ZSL ,
  I_YSL            =:NEW.I_YSL ,
  I_BSL            =:NEW.I_BSL ,
  I_TL            =:NEW.I_TL ,
  I_SZ             =:NEW.I_SZ ,
  I_ZXZ            =:NEW.I_ZXZ ,
  I_YXZ            =:NEW.I_YXZ ,
  I_QGJB           =:NEW.I_QGJB ,
  C_TJRQ   =:NEW.C_TJRQ ,
  C_TJYYMC         =:NEW.C_TJYYMC ,
  C_PHOTO_SRC      =:NEW.C_PHOTO_SRC ,
  BLOB_PHOTO       =:NEW.BLOB_PHOTO ,
  I_PHOTO_SYN      =:NEW.I_PHOTO_SYN ,
  C_JXDM           =:NEW.C_JXDM ,
  C_LSH            =:NEW.C_LSH ,
  C_XM             =:NEW.C_XM ,
  C_CHECK_RESULT =:NEW.C_CHECK_RESULT ,
  C_CHECK_OPERATOR =:NEW.C_CHECK_OPERATOR ,
  C_CHECK_DATE  =:NEW.C_CHECK_DATE ,
  I_CHECKED   =:NEW.I_CHECKED   ,
  C_PHOTO_SYN =:NEW.C_PHOTO_SYN
   
   where id=:NEW.id and i_checked!=1;
end ;

/
ALTER TRIGGER "ASPNET"."TR_UI_STUDENT_APPLY_INFO_I" ENABLE;





CREATE OR REPLACE TRIGGER "ASPNET"."TR_AI_STUDENT_APPLY_INFO_I" after insert on TABLE_STUDENT_APPLY_INFO_I
for each row
begin

      insert into TABLE_STUDENT_APPLY_INFO_C (
        ID  ,
  SFZMHM    ,
  SFZMMC    ,
  I_HMCD    ,
  I_XB             ,
  C_CSRQ          ,
  C_GJ             ,
  C_DJZSXZQH       ,
  C_DJZSXXDZ       ,
  C_LXZSXZQH      ,
  C_LXZSXXDZ       ,
  C_LXZSYZBM       ,
  C_LY            ,
  C_XZQH           ,
  C_LXDH          ,
  C_ZZZM ,
  C_ZKZMBH         ,
  C_DABH          ,
  C_ZKCX           ,
  C_JXMC          ,
  C_DZYX           ,
  C_SJHM           ,
  C_SG ,
  I_ZSL            ,
  I_YSL            ,
  I_BSL            ,
  I_TL            ,
  I_SZ             ,
  I_ZXZ            ,
  I_YXZ            ,
  I_QGJB           ,
  C_TJRQ   ,
  C_TJYYMC         ,
  C_PHOTO_SRC      ,
  BLOB_PHOTO       ,
  I_PHOTO_SYN      ,
  C_JXDM           ,
  C_LSH            ,
  C_XM             ,
  C_CHECK_RESULT ,
  C_CHECK_OPERATOR ,
  C_CHECK_DATE  ,
  I_CHECKED      ,
  C_PHOTO_SYN
      )
      values(
         :NEW.ID  ,
         :NEW.SFZMHM    ,
         :NEW.SFZMMC    ,
         :NEW.I_HMCD    ,
         :NEW.I_XB             ,
         :NEW.C_CSRQ          ,
         :NEW.C_GJ             ,
         :NEW.C_DJZSXZQH       ,
         :NEW.C_DJZSXXDZ       ,
         :NEW.C_LXZSXZQH      ,
         :NEW.C_LXZSXXDZ       ,
         :NEW.C_LXZSYZBM       ,
         :NEW.C_LY            ,
         :NEW.C_XZQH           ,
         :NEW.C_LXDH          ,
         :NEW.C_ZZZM ,
         :NEW.C_ZKZMBH         ,
         :NEW.C_DABH          ,
         :NEW.C_ZKCX           ,
         :NEW.C_JXMC          ,
         :NEW.C_DZYX           ,
         :NEW.C_SJHM           ,
         :NEW.C_SG ,
         :NEW.I_ZSL            ,
         :NEW.I_YSL            ,
         :NEW.I_BSL            ,
         :NEW.I_TL            ,
         :NEW.I_SZ             ,
         :NEW.I_ZXZ            ,
         :NEW.I_YXZ            ,
         :NEW.I_QGJB           ,
         :NEW.C_TJRQ   ,
         :NEW.C_TJYYMC         ,
         :NEW.C_PHOTO_SRC      ,
         :NEW.BLOB_PHOTO       ,
         :NEW.I_PHOTO_SYN      ,
         :NEW.C_JXDM           ,
         :NEW.C_LSH            ,
         :NEW.C_XM             ,
         :NEW.C_CHECK_RESULT ,
         :NEW.C_CHECK_OPERATOR ,
         :NEW.C_CHECK_DATE  ,
         :NEW.I_CHECKED      ,
         :NEW.C_PHOTO_SYN

      );



end;

/
ALTER TRIGGER "ASPNET"."TR_AI_STUDENT_APPLY_INFO_I" ENABLE;
