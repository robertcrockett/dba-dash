﻿CREATE ROLE [Reports]
    AUTHORIZATION [dbo];

GO
GRANT SELECT ON SCHEMA::dbo TO [Reports]
GO
GRANT EXECUTE ON SCHEMA::[Report] TO [Reports];