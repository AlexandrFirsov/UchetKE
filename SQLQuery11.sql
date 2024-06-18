go
use MyDB
select number, equipment.id, name_of, quantity, type_of_equip.type_of, (_name +' '+lastname+' '+surname) as FIO from equipment
                LEFT JOIN respons_person ON respons_person.id = equipment.respons_pers 
                LEFT JOIN type_of_equip ON type_of_equip.id = equipment.type_of 