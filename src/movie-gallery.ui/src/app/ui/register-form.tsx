'use client';

import { lusitana } from '@/app/ui/fonts';
import {
  AtSymbolIcon,
  KeyIcon,
  ExclamationCircleIcon,
} from '@heroicons/react/24/outline';
import { ArrowRightIcon } from '@heroicons/react/20/solid';
import { Button } from './button';
import { useFormState } from "react-dom"
import { register } from "@/app/lib/actions";

export default function RegisterForm() {
  const initialState = { message: "", errors: {} };
  const [state, dispatch] = useFormState(register, initialState);

  return (
    <div className="flex justify-center items-center h-screen">
      <form action={dispatch} className="space-y-3">
        <div className="flex-1 rounded-lg w-96 px-6 pb-4 pt-8">
          <h1 className={`${lusitana.className} mb-3 text-2xl`}>
            Please, register your account.
          </h1>
          <div className="w-full">
            <div>
              <label
                className="mb-3 mt-5 block text-xs font-medium text-gray-900"
                htmlFor="email"
              >
                First Name
              </label>
              <div className="relative">
                <input
                  className="peer block w-full rounded-md border border-gray-200 py-[9px] pl-10 text-sm outline-2 text-black placeholder:text-gray-500"
                  id="email"
                  type="text"
                  name="firstName"
                  placeholder="Enter your email address"
                  required
                />
              </div>
              <div id="user-error" aria-live="polite" aria-atomic="true">
                {state?.errors?.firstName &&
                  state.errors.firstName.map((error: string) => (
                    <>
                      <p className="mt-2 text-sm text-red-500" key={error}>
                        {error}
                      </p>
                      <p className="mt-2 text-sm text-red-500" key={error}>
                        {state.message}
                      </p>
                    </>
                  ))}
              </div>
            </div>

            <div>
              <label
                className="mb-3 mt-5 block text-xs font-medium text-gray-900"
                htmlFor="email"
              >
                Last Name
              </label>
              <div className="relative">
                <input
                  className="peer block w-full rounded-md border border-gray-200 py-[9px] pl-10 text-sm outline-2 text-black placeholder:text-gray-500"
                  id="email"
                  type="text"
                  name="lastName"
                  placeholder="Enter your email address"
                  required
                />
              </div>
              <div id="user-error" aria-live="polite" aria-atomic="true">
                {state.errors?.lastName &&
                  state.errors.lastName.map((error: string) => (
                    <p className="mt-2 text-sm text-red-500" key={error}>
                      {error}
                    </p>
                  ))}
              </div>
            </div>
          </div>

          <div>
            <label
              className="mb-3 mt-5 block text-xs font-medium text-gray-900"
              htmlFor="email"
            >
              Email
            </label>
            <div className="relative">
              <input
                className="peer block w-full rounded-md border border-gray-200 py-[9px] pl-10 text-sm outline-2 text-black placeholder:text-gray-500"
                id="email"
                type="email"
                name="email"
                placeholder="Enter your email address"
                required
              />
              <AtSymbolIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
              <div id="user-error" aria-live="polite" aria-atomic="true">
                {state.errors?.email &&
                  state.errors.email.map((error: string) => (
                    <p className="mt-2 text-sm text-red-500" key={error}>
                      {error}
                    </p>
                  ))}
              </div>
            </div>

          </div>
          <div className="mt-4">
            <label
              className="mb-3 mt-5 block text-xs font-medium text-gray-900"
              htmlFor="password"
            >
              Password
            </label>
            <div className="relative">
              <input
                className="peer block w-full rounded-md border border-gray-200 py-[9px] pl-10 text-sm outline-2 text-black placeholder:text-gray-500"
                id="password"
                type="password"
                name="password"
                placeholder="Enter password"
                required
                minLength={6}
              />
              <KeyIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
              <div id="user-error" aria-live="polite" aria-atomic="true">
                {state.errors?.password &&
                  state.errors.password.map((error: string) => (
                    <p className="mt-2 text-sm text-red-500" key={error}>
                      {error}
                    </p>
                  ))}
              </div>
            </div>
          </div>

          <div className="mt-4">
            <label
              className="mb-3 mt-5 block text-xs font-medium text-gray-900"
              htmlFor="password"
            >
              Confirm Password
            </label>
            <div className="relative">
              <input
                className="peer block w-full rounded-md border border-gray-200 py-[9px] pl-10 text-sm outline-2 text-black placeholder:text-gray-500"
                id="password"
                type="password"
                name="confirmPassword"
                placeholder="Enter password"
                required
                minLength={6}
              />
              <KeyIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
              {state?.errors?.confirmPassword && <div id="user-error" aria-live="polite" aria-atomic="true">
                {state.errors.confirmPassword.map((error: string) => (
                  <p className="mt-2 text-sm text-red-500" key={error}>
                    {error}
                  </p>
                ))}
              </div>}
            </div>
            {state?.message && <div id="user-error" aria-live="polite" aria-atomic="true">
              <p className="mt-2 text-sm text-red-500">
                {state.message}
              </p>
            </div>}
          </div>
          <Button type="submit" className="mt-4">Register</Button>
        </div>
      </form >
    </div>
  );
}