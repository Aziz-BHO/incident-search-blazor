CREATE EXTENSION IF NOT EXISTS pg_trgm;

CREATE TABLE person (
  id SERIAL PRIMARY KEY,
  last_name TEXT NOT NULL,
  first_name TEXT NOT NULL,
  email TEXT NULL
);
 
CREATE TABLE incident (
  id SERIAL PRIMARY KEY,
  title TEXT NOT NULL,
  description TEXT NOT NULL,
  severity TEXT NOT NULL,
  owner_id INTEGER NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT NOW(),
  FOREIGN KEY (owner_id) REFERENCES person(id)
);
 
CREATE INDEX idx_person_id ON person(id);
CREATE INDEX idx_incident_id ON incident(id);

CREATE INDEX idx_incident_title_trgm
ON incident
USING gin (title gin_trgm_ops);

CREATE INDEX idx_incident_description_trgm
ON incident
USING gin (description gin_trgm_ops);

CREATE INDEX idx_person_search_trgm
ON person
USING gin ((first_name || ' ' || last_name || ' ' || email) gin_trgm_ops);