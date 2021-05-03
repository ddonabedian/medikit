﻿import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
    issuer: process.env.OPENID_URL,
    clientId: 'medikitWebsite',
    scope: 'openid profile email role',
    redirectUri: process.env.REDIRECT_URL,
    responseType: 'id_token',
    requireHttps: false
}