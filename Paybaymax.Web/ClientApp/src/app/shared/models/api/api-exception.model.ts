import { ApiExceptionCode } from './api-exception-code.model';

export interface ApiException {
  exceptionCode: ApiExceptionCode;
  exceptionMessage: string;
}
