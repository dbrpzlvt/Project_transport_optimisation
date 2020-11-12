select top 100 * 
from [dbo].[tWay] W
inner join [dbo].[tWayTag] Tag 
    on Tag.WayId = W.Id
inner join [dbo].[tTagType] [Type]
    on [Type].Typ = Tag.Typ
where --[Type].Name = N'addr:street' and 
    Tag.Info like  N'Малая конюшенная улица'