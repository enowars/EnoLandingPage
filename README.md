# EnoLandingPage

## docker-compose
```yaml
version: '3'

services:
  enolandingpage:
    build: .
    environment:
      - "EnoLandingPage__Title=FoobarCTF"
      - "EnoLandingPage__StartTime=2020-11-22T15:00:00Z"
      - "EnoLandingPage__RegistrationCloseOffset=48"
      - "EnoLandingPage__CheckInBeginOffset=12"
      - "EnoLandingPage__CheckInEndOffset=2"
      - "EnoLandingPage__HetznerVulnboxType=cx11"
      - "EnoLandingPage__HetznerCloudApiToken=..."
      - "EnoLandingPage__HetznerVulnboxImage=..."
      - "EnoLandingPage__HetznerVulnboxPubkey=..."
      - "EnoLandingPage__HetznerVulnboxLocation=..."
      - "EnoLandingPage__OAuthClientId=..."
      - "EnoLandingPage__OAuthClientSecret=..."
    ports:
      - "5001:80"
    volumes:
      - ./sessions:/root/.aspnet/DataProtection-Keys
      - ./data:/app/data
```

## Reverse Proxy Configuration
The reverse proxy must set the [XFP header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-Proto) and allow https connections.
