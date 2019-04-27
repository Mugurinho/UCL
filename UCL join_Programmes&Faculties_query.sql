select 
ProgrammeTitle,
ProgrammeDescription,
ProgrammeFee
from Programmes

select
FacultyId,
FacultyName
from Faculties

select 
ProgrammeTitle,
ProgrammeDescription,
ProgrammeFee,
f.FacultyName
from Programmes
JOIN Faculties as f
ON Programmes.FacultyId = f.FacultyId;


