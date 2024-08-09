 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44317/',
  redirectUri: baseUrl,
  clientId: 'LawMax_App',
  responseType: 'code',
  scope: 'offline_access LawMax',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'LawMax',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44317',
      rootNamespace: 'Inva.LawMax',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
