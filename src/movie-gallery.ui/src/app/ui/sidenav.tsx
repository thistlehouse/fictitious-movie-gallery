import Link from "next/link";

export default function SideNav() {
  return (
    <>
      <div className="mt-5 mx-60">
        <ul className="px-50 flex gap-5 justify-end">
          <Link href="/register">
            <li>Register</li>
          </Link>
          <Link href="">
            <li>Login</li>
          </Link>
        </ul>
      </div>
    </>
  );
}