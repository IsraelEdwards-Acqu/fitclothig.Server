BEGIN;
BEGIN;

ALTER TABLE "Products"
    ADD COLUMN IF NOT EXISTS "IsTrending" boolean NOT NULL DEFAULT false,
    ADD COLUMN IF NOT EXISTS "IsBestSeller" boolean NOT NULL DEFAULT false,
    ADD COLUMN IF NOT EXISTS "HasNoMinimum" boolean NOT NULL DEFAULT false,
    ADD COLUMN IF NOT EXISTS "Rating" numeric NOT NULL DEFAULT 0,
    ADD COLUMN IF NOT EXISTS "ReviewCount" integer NOT NULL DEFAULT 0,
    ADD COLUMN IF NOT EXISTS "IsNewArrival" boolean NOT NULL DEFAULT false,
    ADD COLUMN IF NOT EXISTS "DateAdded" timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ADD COLUMN IF NOT EXISTS "ThumbnailUrl" text NOT NULL DEFAULT '',
    ADD COLUMN IF NOT EXISTS "BrandName" text NOT NULL DEFAULT '',
    ADD COLUMN IF NOT EXISTS "CategoryName" text NOT NULL DEFAULT '',
    ADD COLUMN IF NOT EXISTS "MinimumOrderQuantity" integer NOT NULL DEFAULT 1,
    ADD COLUMN IF NOT EXISTS "AllowSingleOrder" boolean NOT NULL DEFAULT false,
    ADD COLUMN IF NOT EXISTS "HasFrontDesign" boolean NOT NULL DEFAULT true,
    ADD COLUMN IF NOT EXISTS "HasBackDesign" boolean NOT NULL DEFAULT true;

UPDATE "Products" AS p
SET
    "BrandName" = COALESCE(NULLIF(b."Name", ''), p."BrandName"),
    "CategoryName" = COALESCE(NULLIF(c."Name", ''), p."CategoryName"),
    "ThumbnailUrl" = COALESCE(NULLIF(p."ThumbnailUrl", ''), p."ImageUrl"),
    "DateAdded" = COALESCE(p."DateAdded", p."CreatedAt")
FROM "Brands" AS b
JOIN "Categories" AS c ON c."Id" = p."CategoryId"
WHERE b."Id" = p."BrandId";

CREATE INDEX IF NOT EXISTS "IX_Products_IsActive_IsNewArrival_DateAdded"
    ON "Products" ("IsActive", "IsNewArrival", "DateAdded" DESC);

COMMIT;

SELECT "Id", "Name", "Slug", "CategoryId", "BrandId", "IsActive", "IsNewArrival", "DateAdded"
FROM "Products"
ORDER BY "DateAdded" DESC;
